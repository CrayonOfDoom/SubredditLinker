using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RedditSharp;
using HtmlAgilityPack;
using System.Threading;

namespace SubredditLinker
{
    public partial class mainwindow : Form
    {
        // Reddit access info
        public Reddit mainReddit;
        public HtmlWeb web;

        // Main subreddit info
        public string mainSubreddit;
        public bool isValid;
        public IEnumerable<ModeratorUser> moderators;

        // Structure for holding all the subs that the moderators mod
        public List<string> modNames;
        public List<List<string>> modSubsList;

        // Misc needed things
        public int barNumber;

        public mainwindow()
        {
            InitializeComponent();

            // Accept button should be set
            this.AcceptButton = buttonAnalyze;

            mainReddit = new Reddit(); // Get a "reddit" instance.
            web = new HtmlWeb();

            modNames = new List<string>();
            modSubsList = new List<List<string>>();
            barNumber = 1;
        }

        private void buttonAnalyze_Click(object sender, EventArgs e)
        {
            if (!buttonAnalyze.Enabled)
                return; // How did this even happen?

            // Restore some values
            modNames = new List<string>();
            modSubsList = new List<List<string>>();
            treeViewResults.Nodes.Clear();
            treeViewSub.Nodes.Clear();

            // Validate textBoxSubreddit text
            mainSubreddit = textBoxSubreddit.Text;
            // Remove superfluous info in subreddit
            stripSubreddit();

            // Re-add the /r/
            string arrrr = "/r/";
            mainSubreddit = arrrr + mainSubreddit;

            // DUMMY, display a new subreddit
            textBoxSubreddit.Text = mainSubreddit;

            isValid = isValidSubreddit();

            getMods(); // Just gets the name of the mods.

            // We should do this in a thread of some sort with a progress bar.
            progressBarMain.Minimum = 1;
            progressBarMain.Maximum = moderators.Count();

            Thread thread = new Thread(fillList);
            thread.IsBackground = true;
            thread.Start();
        }

        private void stripSubreddit()
        {
            // Check mainSubreddit for slashes before
            string parsedSubreddit;
            if (mainSubreddit.Contains("r/")) // It's a link, not just the sub.  Parse up to the / after /r/
            {
                int loc = mainSubreddit.IndexOf("/");
                parsedSubreddit = mainSubreddit.Substring(loc + 3);

                mainSubreddit = parsedSubreddit;

                stripSubreddit(); // might need more parsing, recurse until we've stripped up to the r/
            }
            else if(mainSubreddit.Contains("/")) // if we've made it this far, look for the final /
            {
                // Strip off everything but what's before the slash
                int loc = mainSubreddit.IndexOf("/");
                parsedSubreddit = mainSubreddit.Substring(0, loc);

                mainSubreddit = parsedSubreddit;

                stripSubreddit(); // recurse just in case.
            }
        }

        private bool isValidSubreddit()
        {
            return true; // dummy value until we have a way to validate subs
        }

        private void getMods()
        {
            // Let's see if we can get mods
            var subreddit = mainReddit.GetSubreddit(mainSubreddit);

            moderators = subreddit.Moderators;
        }


        // BEGIN THREADING!
        private void fillList()
        {
            // Lock out everything, reset progressbar
            barNumber = 1;

            buttonAnalyze.Invoke((MethodInvoker)(() => buttonAnalyze.Enabled = false));

            foreach (ModeratorUser mod in moderators) // For each moderator that we got from reddit...
            {
                string name = mod.Name; // Assign a name.

                if (name == "AutoModerator") // Skip AutoModerator, it's useless and takes forever
                    continue;

                List<string> subreddits = getSubList(name); // Get a List<string> with their subreddits

                // We have their name and a list of subreddits, add a tree node
                TreeNode node = new TreeNode(name); // ID is the mod name
                node.Name = name; // for manual node finding
                foreach (string sub in subreddits) // For each subreddit...
                {
                    TreeNode subredditNode = new TreeNode(sub); // ID is the sub name
                    subredditNode.Name = sub; // For manual node finding
                    node.Nodes.Add(subredditNode); // Add the node

                    // Update treeViewSub
                    TreeNode[] itemNode = treeViewSub.Nodes.Find(sub, false); // Do we have this sub in the tree?

                    if (itemNode.Length == 0) // Not found, add it
                    {
                        TreeNode newNode = new TreeNode(sub);
                        newNode.Name = sub;
                        newNode.Nodes.Add(name);
                        // ADD
                        treeViewSub.Invoke((MethodInvoker)(() => treeViewSub.Nodes.Add(newNode)));
                    }
                    else // Found, update it
                    {
                        treeViewSub.Invoke((MethodInvoker)(() => itemNode[0].Nodes.Add(name)));
                    }
                    
                }

                // ADD
                treeViewResults.Invoke((MethodInvoker)(() => treeViewResults.Nodes.Add(node)));

                Update1(barNumber); // Move the progress bar
                barNumber++; // Incriment the progress bar
            }

            // Final Update
            updateSubredditsByCount();

            // Unlock
            buttonAnalyze.Invoke((MethodInvoker)(() => buttonAnalyze.Enabled = true));
        }

        private List<string> getSubList(string modName)
        {
            List<string> retList = new List<string>();

            string Url = "http://www.reddit.com/user/" + modName;
            HtmlAgilityPack.HtmlDocument doc = web.Load(Url);
            HtmlNode sideModList = doc.DocumentNode.SelectSingleNode("//ul[@id='side-mod-list']");

            // Check that the user isn't banned...
            bool banned = false;
            if (sideModList == null)
                banned = true;

            if (!banned)
            {
                // We have the node, get the subnodes
                HtmlNodeCollection subNodes = sideModList.ChildNodes;

                foreach (HtmlNode node in subNodes)
                {
                    HtmlNode innerNode = node.FirstChild;
                    // innerNode.InnerText = the sub!
                    retList.Add(innerNode.InnerText);
                }
            }
            else
            {
                retList.Add("USER IS BANNED");
            }

            return retList;
        }

        private void updateSubredditsByCount()
        {
            // treeViewSub has a handful of stuff in it.  We want them to be ordered by number of children.
            TreeNodeCollection allNodes = treeViewSub.Nodes;
            Dictionary<TreeNode, int> nodeDict = new Dictionary<TreeNode, int>();
            List<TreeNode> finalList = new List<TreeNode>();

            // First fill
            foreach (TreeNode node in allNodes)
            {
                int count = node.GetNodeCount(false);
                nodeDict[node] = count;
            }

            // Now that it's filled with counts, we need the highest count.
            while(nodeDict.Count > 0)
            {
                int top = 0;
                TreeNode topNode = null;

                foreach (KeyValuePair<TreeNode, int> pair in nodeDict)
                {
                    if (pair.Value > top)
                    {
                        top = pair.Value;
                        topNode = pair.Key;
                    }
                }

                if (topNode != null) // found one, remove it
                {
                    treeViewSub.Invoke((MethodInvoker)(() => topNode.Text = topNode.Text + " (" + topNode.Nodes.Count + ")"));
                    //topNode.Text = topNode.Text + " (" + topNode.Nodes.Count + ")";
                    finalList.Add(topNode);
                    nodeDict.Remove(topNode);
                }
            }

            // Now we have a "finalList" that's filled.  Update treeviewSub with new values
            treeViewSub.Invoke((MethodInvoker)(() => treeViewSub.Nodes.Clear())); // clear
            
            for(int i = 0; i < finalList.Count; i++)
            {
                treeViewSub.Invoke((MethodInvoker)(() => treeViewSub.Nodes.Add(finalList[i])));
            }
        }

        public void Update1(int i)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<int>(Update1), new object[] { i });
                return;
            }

            progressBarMain.Value = i;
        }
    }
}
