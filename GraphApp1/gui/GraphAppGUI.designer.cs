namespace GraphApp.src.gui
{
    partial class GraphAppGUI
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphAppGUI));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCurrentGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blankGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commonOpsToolStrip = new System.Windows.Forms.ToolStrip();
            this.newGraphButton = new System.Windows.Forms.ToolStripButton();
            this.newFlowNetworkButton = new System.Windows.Forms.ToolStripButton();
            this.openGraphButton = new System.Windows.Forms.ToolStripButton();
            this.deleteGraphButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.vertexFilterButton = new System.Windows.Forms.ToolStripButton();
            this.edgeFilterButton = new System.Windows.Forms.ToolStripButton();
            this.deleteElementButton = new System.Windows.Forms.ToolStripButton();
            this.quickToolStrip = new System.Windows.Forms.ToolStrip();
            this.selectToolButton = new System.Windows.Forms.ToolStripButton();
            this.moveToolButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.selectedItemPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.graphTabControl = new System.Windows.Forms.TabControl();
            this.graphRightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.randomGraphButton = new System.Windows.Forms.ToolStripButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.mstButton = new System.Windows.Forms.ToolStripButton();
            this.kruskalButton = new System.Windows.Forms.ToolStripButton();
            this.DijkstraButton = new System.Windows.Forms.ToolStripButton();
            this.labelCorrectingButton = new System.Windows.Forms.ToolStripButton();
            this.allPairsButton = new System.Windows.Forms.ToolStripButton();
            this.maxFlowButton = new System.Windows.Forms.ToolStripButton();
            this.minDomSetButton = new System.Windows.Forms.ToolStripButton();
            this.printMatrixButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addVertexToolButton = new System.Windows.Forms.ToolStripButton();
            this.addEdgeToolButton = new System.Windows.Forms.ToolStripButton();
            this.toolTabControl = new System.Windows.Forms.TabControl();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.commonOpsToolStrip.SuspendLayout();
            this.quickToolStrip.SuspendLayout();
            this.graphRightClickMenu.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolTabControl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.createToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(933, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGraphToolStripMenuItem,
            this.openToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newGraphToolStripMenuItem
            // 
            this.newGraphToolStripMenuItem.Name = "newGraphToolStripMenuItem";
            this.newGraphToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.newGraphToolStripMenuItem.Text = "New Graph";
            this.newGraphToolStripMenuItem.Click += new System.EventHandler(this.onNewGraphClick);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.onQuit);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteCurrentGraphToolStripMenuItem,
            this.deleteSelectedToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // deleteCurrentGraphToolStripMenuItem
            // 
            this.deleteCurrentGraphToolStripMenuItem.Name = "deleteCurrentGraphToolStripMenuItem";
            this.deleteCurrentGraphToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.deleteCurrentGraphToolStripMenuItem.Text = "Delete Current Graph";
            this.deleteCurrentGraphToolStripMenuItem.Click += new System.EventHandler(this.onGraphDelete);
            // 
            // deleteSelectedToolStripMenuItem
            // 
            this.deleteSelectedToolStripMenuItem.Name = "deleteSelectedToolStripMenuItem";
            this.deleteSelectedToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.deleteSelectedToolStripMenuItem.Text = "Delete Selected";
            this.deleteSelectedToolStripMenuItem.Click += new System.EventHandler(this.onDeleteSelected);
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blankGraphToolStripMenuItem});
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.createToolStripMenuItem.Text = "Create";
            // 
            // blankGraphToolStripMenuItem
            // 
            this.blankGraphToolStripMenuItem.Name = "blankGraphToolStripMenuItem";
            this.blankGraphToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.blankGraphToolStripMenuItem.Text = "Blank Graph";
            this.blankGraphToolStripMenuItem.Click += new System.EventHandler(this.onNewGraphClick);
            // 
            // commonOpsToolStrip
            // 
            this.commonOpsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGraphButton,
            this.newFlowNetworkButton,
            this.openGraphButton,
            this.deleteGraphButton,
            this.toolStripSeparator3,
            this.vertexFilterButton,
            this.edgeFilterButton,
            this.deleteElementButton});
            this.commonOpsToolStrip.Location = new System.Drawing.Point(0, 24);
            this.commonOpsToolStrip.Name = "commonOpsToolStrip";
            this.commonOpsToolStrip.Size = new System.Drawing.Size(933, 39);
            this.commonOpsToolStrip.TabIndex = 1;
            this.commonOpsToolStrip.Text = "toolStrip1";
            // 
            // newGraphButton
            // 
            this.newGraphButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newGraphButton.Image = ((System.Drawing.Image)(resources.GetObject("newGraphButton.Image")));
            this.newGraphButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.newGraphButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newGraphButton.Name = "newGraphButton";
            this.newGraphButton.Size = new System.Drawing.Size(36, 36);
            this.newGraphButton.Text = "New Graph";
            this.newGraphButton.Click += new System.EventHandler(this.onNewGraphClick);
            // 
            // newFlowNetworkButton
            // 
            this.newFlowNetworkButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newFlowNetworkButton.Image = ((System.Drawing.Image)(resources.GetObject("newFlowNetworkButton.Image")));
            this.newFlowNetworkButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.newFlowNetworkButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newFlowNetworkButton.Name = "newFlowNetworkButton";
            this.newFlowNetworkButton.Size = new System.Drawing.Size(36, 36);
            this.newFlowNetworkButton.Text = "New Flow Network";
            this.newFlowNetworkButton.Click += new System.EventHandler(this.onNewFlowNetwork);
            // 
            // openGraphButton
            // 
            this.openGraphButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openGraphButton.Image = ((System.Drawing.Image)(resources.GetObject("openGraphButton.Image")));
            this.openGraphButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openGraphButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openGraphButton.Name = "openGraphButton";
            this.openGraphButton.Size = new System.Drawing.Size(36, 36);
            this.openGraphButton.Text = "Open Graph";
            // 
            // deleteGraphButton
            // 
            this.deleteGraphButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteGraphButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteGraphButton.Image")));
            this.deleteGraphButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteGraphButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteGraphButton.Name = "deleteGraphButton";
            this.deleteGraphButton.Size = new System.Drawing.Size(36, 36);
            this.deleteGraphButton.Text = "Delete Graph";
            this.deleteGraphButton.Click += new System.EventHandler(this.onGraphDelete);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // vertexFilterButton
            // 
            this.vertexFilterButton.Checked = true;
            this.vertexFilterButton.CheckOnClick = true;
            this.vertexFilterButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.vertexFilterButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.vertexFilterButton.Image = ((System.Drawing.Image)(resources.GetObject("vertexFilterButton.Image")));
            this.vertexFilterButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.vertexFilterButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.vertexFilterButton.Name = "vertexFilterButton";
            this.vertexFilterButton.Size = new System.Drawing.Size(36, 36);
            this.vertexFilterButton.Text = "Filter Vertices";
            this.vertexFilterButton.Click += new System.EventHandler(this.onFilterVertexClick);
            // 
            // edgeFilterButton
            // 
            this.edgeFilterButton.Checked = true;
            this.edgeFilterButton.CheckOnClick = true;
            this.edgeFilterButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.edgeFilterButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.edgeFilterButton.Image = ((System.Drawing.Image)(resources.GetObject("edgeFilterButton.Image")));
            this.edgeFilterButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.edgeFilterButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.edgeFilterButton.Name = "edgeFilterButton";
            this.edgeFilterButton.Size = new System.Drawing.Size(36, 36);
            this.edgeFilterButton.Text = "Filter Edges";
            this.edgeFilterButton.Click += new System.EventHandler(this.onFilterEdgeClick);
            // 
            // deleteElementButton
            // 
            this.deleteElementButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteElementButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteElementButton.Image")));
            this.deleteElementButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteElementButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteElementButton.Name = "deleteElementButton";
            this.deleteElementButton.Size = new System.Drawing.Size(36, 36);
            this.deleteElementButton.Text = "toolStripButton2";
            this.deleteElementButton.Click += new System.EventHandler(this.onDeleteSelected);
            // 
            // quickToolStrip
            // 
            this.quickToolStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.quickToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.quickToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectToolButton,
            this.moveToolButton,
            this.toolStripSeparator1});
            this.quickToolStrip.Location = new System.Drawing.Point(0, 127);
            this.quickToolStrip.MinimumSize = new System.Drawing.Size(36, 0);
            this.quickToolStrip.Name = "quickToolStrip";
            this.quickToolStrip.Size = new System.Drawing.Size(37, 394);
            this.quickToolStrip.TabIndex = 3;
            this.quickToolStrip.Text = "toolStrip2";
            // 
            // selectToolButton
            // 
            this.selectToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.selectToolButton.Image = ((System.Drawing.Image)(resources.GetObject("selectToolButton.Image")));
            this.selectToolButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.selectToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectToolButton.Name = "selectToolButton";
            this.selectToolButton.Size = new System.Drawing.Size(34, 36);
            this.selectToolButton.Text = "Select";
            this.selectToolButton.Click += new System.EventHandler(this.onSelectToolClick);
            // 
            // moveToolButton
            // 
            this.moveToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveToolButton.Image = ((System.Drawing.Image)(resources.GetObject("moveToolButton.Image")));
            this.moveToolButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.moveToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveToolButton.Name = "moveToolButton";
            this.moveToolButton.Size = new System.Drawing.Size(34, 36);
            this.moveToolButton.Text = "Move";
            this.moveToolButton.Click += new System.EventHandler(this.onMoveToolClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(34, 6);
            // 
            // selectedItemPropertyGrid
            // 
            this.selectedItemPropertyGrid.Dock = System.Windows.Forms.DockStyle.Right;
            this.selectedItemPropertyGrid.Location = new System.Drawing.Point(751, 127);
            this.selectedItemPropertyGrid.Name = "selectedItemPropertyGrid";
            this.selectedItemPropertyGrid.Size = new System.Drawing.Size(182, 394);
            this.selectedItemPropertyGrid.TabIndex = 4;
            this.selectedItemPropertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.onPropertyChange);
            // 
            // graphTabControl
            // 
            this.graphTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphTabControl.Location = new System.Drawing.Point(37, 127);
            this.graphTabControl.Name = "graphTabControl";
            this.graphTabControl.SelectedIndex = 0;
            this.graphTabControl.Size = new System.Drawing.Size(714, 250);
            this.graphTabControl.TabIndex = 6;
            this.graphTabControl.SelectedIndexChanged += new System.EventHandler(this.onTabChange);
            // 
            // graphRightClickMenu
            // 
            this.graphRightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.graphRightClickMenu.Name = "graphRightClickMenu";
            this.graphRightClickMenu.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.onGraphDelete);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.toolStrip2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(925, 38);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Generate";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.randomGraphButton});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(925, 38);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // randomGraphButton
            // 
            this.randomGraphButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.randomGraphButton.Image = ((System.Drawing.Image)(resources.GetObject("randomGraphButton.Image")));
            this.randomGraphButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.randomGraphButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.randomGraphButton.Name = "randomGraphButton";
            this.randomGraphButton.Size = new System.Drawing.Size(36, 35);
            this.randomGraphButton.Text = "randomGraph";
            this.randomGraphButton.Click += new System.EventHandler(this.onGenerateRandomGraph);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.toolStrip3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(925, 38);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Algorithms";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mstButton,
            this.kruskalButton,
            this.DijkstraButton,
            this.labelCorrectingButton,
            this.allPairsButton,
            this.maxFlowButton,
            this.minDomSetButton,
            this.printMatrixButton,
            this.toolStripButton2});
            this.toolStrip3.Location = new System.Drawing.Point(3, 3);
            this.toolStrip3.MinimumSize = new System.Drawing.Size(0, 40);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(919, 40);
            this.toolStrip3.TabIndex = 0;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // mstButton
            // 
            this.mstButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mstButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mstButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mstButton.Name = "mstButton";
            this.mstButton.Size = new System.Drawing.Size(36, 37);
            this.mstButton.Text = "Prim";
            this.mstButton.Click += new System.EventHandler(this.onPrimButtonClick);
            // 
            // kruskalButton
            // 
            this.kruskalButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.kruskalButton.Image = ((System.Drawing.Image)(resources.GetObject("kruskalButton.Image")));
            this.kruskalButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.kruskalButton.Name = "kruskalButton";
            this.kruskalButton.Size = new System.Drawing.Size(49, 37);
            this.kruskalButton.Text = "Kruskal";
            this.kruskalButton.Click += new System.EventHandler(this.onKruskalClick);
            // 
            // DijkstraButton
            // 
            this.DijkstraButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DijkstraButton.Image = ((System.Drawing.Image)(resources.GetObject("DijkstraButton.Image")));
            this.DijkstraButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DijkstraButton.Name = "DijkstraButton";
            this.DijkstraButton.Size = new System.Drawing.Size(50, 37);
            this.DijkstraButton.Text = "Dijkstra";
            this.DijkstraButton.Click += new System.EventHandler(this.onDijkstraClick);
            // 
            // labelCorrectingButton
            // 
            this.labelCorrectingButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.labelCorrectingButton.Image = ((System.Drawing.Image)(resources.GetObject("labelCorrectingButton.Image")));
            this.labelCorrectingButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.labelCorrectingButton.Name = "labelCorrectingButton";
            this.labelCorrectingButton.Size = new System.Drawing.Size(98, 37);
            this.labelCorrectingButton.Text = "Label Correcting";
            this.labelCorrectingButton.Click += new System.EventHandler(this.onLabelCorrecting);
            // 
            // allPairsButton
            // 
            this.allPairsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.allPairsButton.Image = ((System.Drawing.Image)(resources.GetObject("allPairsButton.Image")));
            this.allPairsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.allPairsButton.Name = "allPairsButton";
            this.allPairsButton.Size = new System.Drawing.Size(126, 37);
            this.allPairsButton.Text = "All Pairs Shortest Path";
            this.allPairsButton.Click += new System.EventHandler(this.onAllPairs);
            // 
            // maxFlowButton
            // 
            this.maxFlowButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.maxFlowButton.Image = ((System.Drawing.Image)(resources.GetObject("maxFlowButton.Image")));
            this.maxFlowButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.maxFlowButton.Name = "maxFlowButton";
            this.maxFlowButton.Size = new System.Drawing.Size(61, 37);
            this.maxFlowButton.Text = "Max Flow";
            this.maxFlowButton.Click += new System.EventHandler(this.onMaxFlow);
            // 
            // minDomSetButton
            // 
            this.minDomSetButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.minDomSetButton.Image = ((System.Drawing.Image)(resources.GetObject("minDomSetButton.Image")));
            this.minDomSetButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.minDomSetButton.Name = "minDomSetButton";
            this.minDomSetButton.Size = new System.Drawing.Size(149, 37);
            this.minDomSetButton.Text = "Minimum Dominating Set";
            this.minDomSetButton.Click += new System.EventHandler(this.onMinDomSetClick);
            // 
            // printMatrixButton
            // 
            this.printMatrixButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.printMatrixButton.Image = ((System.Drawing.Image)(resources.GetObject("printMatrixButton.Image")));
            this.printMatrixButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printMatrixButton.Name = "printMatrixButton";
            this.printMatrixButton.Size = new System.Drawing.Size(69, 37);
            this.printMatrixButton.Text = "PrintMatrix";
            this.printMatrixButton.Click += new System.EventHandler(this.onPrintMatrix);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(130, 37);
            this.toolStripButton2.Text = "Classify Graph Vertices";
            this.toolStripButton2.Click += new System.EventHandler(this.onGraphClassify);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.toolStrip1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(925, 38);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Build";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addVertexToolButton,
            this.addEdgeToolButton});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.MinimumSize = new System.Drawing.Size(0, 38);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(919, 38);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addVertexToolButton
            // 
            this.addVertexToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addVertexToolButton.Image = ((System.Drawing.Image)(resources.GetObject("addVertexToolButton.Image")));
            this.addVertexToolButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addVertexToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addVertexToolButton.Name = "addVertexToolButton";
            this.addVertexToolButton.Size = new System.Drawing.Size(36, 35);
            this.addVertexToolButton.Text = "Add Vertex Tool";
            this.addVertexToolButton.Click += new System.EventHandler(this.onVertexToolClick);
            // 
            // addEdgeToolButton
            // 
            this.addEdgeToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addEdgeToolButton.Image = ((System.Drawing.Image)(resources.GetObject("addEdgeToolButton.Image")));
            this.addEdgeToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addEdgeToolButton.Name = "addEdgeToolButton";
            this.addEdgeToolButton.Size = new System.Drawing.Size(36, 35);
            this.addEdgeToolButton.Text = "Add Edge";
            this.addEdgeToolButton.Click += new System.EventHandler(this.onAddEdgeToolClick);
            // 
            // toolTabControl
            // 
            this.toolTabControl.Controls.Add(this.tabPage1);
            this.toolTabControl.Controls.Add(this.tabPage2);
            this.toolTabControl.Controls.Add(this.tabPage3);
            this.toolTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolTabControl.Location = new System.Drawing.Point(0, 63);
            this.toolTabControl.MinimumSize = new System.Drawing.Size(0, 42);
            this.toolTabControl.Name = "toolTabControl";
            this.toolTabControl.SelectedIndex = 0;
            this.toolTabControl.Size = new System.Drawing.Size(933, 64);
            this.toolTabControl.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(710, 140);
            this.textBox1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(37, 377);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(714, 144);
            this.panel1.TabIndex = 5;
            // 
            // GraphAppGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.graphTabControl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.selectedItemPropertyGrid);
            this.Controls.Add(this.quickToolStrip);
            this.Controls.Add(this.toolTabControl);
            this.Controls.Add(this.commonOpsToolStrip);
            this.Controls.Add(this.menuStrip1);
            this.Name = "GraphAppGUI";
            this.Size = new System.Drawing.Size(933, 521);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.commonOpsToolStrip.ResumeLayout(false);
            this.commonOpsToolStrip.PerformLayout();
            this.quickToolStrip.ResumeLayout(false);
            this.quickToolStrip.PerformLayout();
            this.graphRightClickMenu.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolTabControl.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStrip commonOpsToolStrip;
        private System.Windows.Forms.ToolStripButton newGraphButton;
        private System.Windows.Forms.ToolStripButton openGraphButton;
        private System.Windows.Forms.ToolStrip quickToolStrip;
        private System.Windows.Forms.ToolStripButton selectToolButton;
        private System.Windows.Forms.ToolStripButton moveToolButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.PropertyGrid selectedItemPropertyGrid;
        private System.Windows.Forms.TabControl graphTabControl;
        private System.Windows.Forms.ContextMenuStrip graphRightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton deleteGraphButton;
        private System.Windows.Forms.ToolStripMenuItem newGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blankGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteCurrentGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton vertexFilterButton;
        private System.Windows.Forms.ToolStripButton edgeFilterButton;
        private System.Windows.Forms.ToolStripButton newFlowNetworkButton;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton randomGraphButton;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton mstButton;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addVertexToolButton;
        private System.Windows.Forms.ToolStripButton addEdgeToolButton;
        private System.Windows.Forms.TabControl toolTabControl;
        private System.Windows.Forms.ToolStripButton deleteElementButton;
        private System.Windows.Forms.ToolStripButton kruskalButton;
        private System.Windows.Forms.ToolStripButton DijkstraButton;
        private System.Windows.Forms.ToolStripButton labelCorrectingButton;
        private System.Windows.Forms.ToolStripButton allPairsButton;
        private System.Windows.Forms.ToolStripButton maxFlowButton;
        private System.Windows.Forms.ToolStripButton minDomSetButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton printMatrixButton;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
    }
}
