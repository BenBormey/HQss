using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace unt_bingoo.view.Sales
{
    partial class guiforSale
    {
        private IContainer components = null;

        private PanelControl panelLeft;
        private PanelControl panelCategory;
        private LabelControl lblMenuCategory;
        private FlowLayoutPanel categoryButtonsPanel;

        private PanelControl panelMenu;
        private LabelControl lblAllMenu;
        private GridControl gridMenu;
        private TileView tileMenu;
        private TileViewColumn colImg;
        private TileViewColumn colName;
        private TileViewColumn colPrice;

        private PanelControl panelRight;
        private PanelControl panelOrderHeader;
        private LabelControl lblOrderTitle;
        private LabelControl lblOrderNo;
        private RadioGroup rdoOrderType;

        private PanelControl panelOrderGrid;
        private GridControl gridOrder;
        private GridView gvOrder;
        private GridColumn colItem;
        private GridColumn colQty;
        private GridColumn colUnitPrice;
        private GridColumn colAmount;
        private GridColumn gridColumn1;
        private GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnmainDecrease;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnCancel;


        private PanelControl panelOrderFooter;
        private LabelControl lblSubTotalText;
        private LabelControl lblSubTotal;
        private LabelControl lblDiscountText;
        private LabelControl lblDiscount;
        private LabelControl lblTotalText;
        private LabelControl lblTotal;
        private SimpleButton btnContinuePayment;
        private SimpleButton btnClearOrder;
        private LabelControl lbldis;
        private LabelControl lbltotals;
        private LabelControl lblsub;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement1 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement2 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement3 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.colImg = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colName = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.panelLeft = new DevExpress.XtraEditors.PanelControl();
            this.panelMenu = new DevExpress.XtraEditors.PanelControl();
            this.gridMenu = new DevExpress.XtraGrid.GridControl();
            this.tileMenu = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.lblAllMenu = new DevExpress.XtraEditors.LabelControl();
            this.panelCategory = new DevExpress.XtraEditors.PanelControl();
            this.categoryButtonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lblMenuCategory = new DevExpress.XtraEditors.LabelControl();
            this.panelRight = new DevExpress.XtraEditors.PanelControl();
            this.panelOrderGrid = new DevExpress.XtraEditors.PanelControl();
            this.gridOrder = new DevExpress.XtraGrid.GridControl();
            this.gvOrder = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnmainDecrease = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCancel = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panelOrderFooter = new DevExpress.XtraEditors.PanelControl();
            this.lbldis = new DevExpress.XtraEditors.LabelControl();
            this.lbltotals = new DevExpress.XtraEditors.LabelControl();
            this.lblsub = new DevExpress.XtraEditors.LabelControl();
            this.lblSubTotalText = new DevExpress.XtraEditors.LabelControl();
            this.lblSubTotal = new DevExpress.XtraEditors.LabelControl();
            this.lblDiscountText = new DevExpress.XtraEditors.LabelControl();
            this.lblDiscount = new DevExpress.XtraEditors.LabelControl();
            this.lblTotalText = new DevExpress.XtraEditors.LabelControl();
            this.lblTotal = new DevExpress.XtraEditors.LabelControl();
            this.btnContinuePayment = new DevExpress.XtraEditors.SimpleButton();
            this.btnClearOrder = new DevExpress.XtraEditors.SimpleButton();
            this.panelOrderHeader = new DevExpress.XtraEditors.PanelControl();
            this.lblOrderTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblOrderNo = new DevExpress.XtraEditors.LabelControl();
            this.rdoOrderType = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.panelLeft)).BeginInit();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelMenu)).BeginInit();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelCategory)).BeginInit();
            this.panelCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelRight)).BeginInit();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelOrderGrid)).BeginInit();
            this.panelOrderGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnmainDecrease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelOrderFooter)).BeginInit();
            this.panelOrderFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelOrderHeader)).BeginInit();
            this.panelOrderHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdoOrderType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // colImg
            // 
            this.colImg.Caption = "Img";
            this.colImg.FieldName = "Img";
            this.colImg.Name = "colImg";
            this.colImg.Visible = true;
            this.colImg.VisibleIndex = 0;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // colPrice
            // 
            this.colPrice.Caption = "Price";
            this.colPrice.FieldName = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 2;
            // 
            // panelLeft
            // 
            this.panelLeft.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelLeft.Controls.Add(this.panelMenu);
            this.panelLeft.Controls.Add(this.panelCategory);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(10, 10);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Padding = new System.Windows.Forms.Padding(10);
            this.panelLeft.Size = new System.Drawing.Size(750, 570);
            this.panelLeft.TabIndex = 1;
            // 
            // panelMenu
            // 
            this.panelMenu.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelMenu.Controls.Add(this.gridMenu);
            this.panelMenu.Controls.Add(this.lblAllMenu);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMenu.Location = new System.Drawing.Point(10, 120);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Padding = new System.Windows.Forms.Padding(10);
            this.panelMenu.Size = new System.Drawing.Size(730, 440);
            this.panelMenu.TabIndex = 0;
            // 
            // gridMenu
            // 
            this.gridMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMenu.Location = new System.Drawing.Point(10, 38);
            this.gridMenu.MainView = this.tileMenu;
            this.gridMenu.Name = "gridMenu";
            this.gridMenu.Size = new System.Drawing.Size(710, 392);
            this.gridMenu.TabIndex = 0;
            this.gridMenu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tileMenu});
            // 
            // tileMenu
            // 
            this.tileMenu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colImg,
            this.colName,
            this.colPrice});
            this.tileMenu.GridControl = this.gridMenu;
            this.tileMenu.Name = "tileMenu";
            this.tileMenu.OptionsTiles.ItemSize = new System.Drawing.Size(220, 160);
            this.tileMenu.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical;
            tileViewItemElement1.Column = this.colImg;
            tileViewItemElement1.Text = "";
            tileViewItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement2.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            tileViewItemElement2.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement2.Column = this.colName;
            tileViewItemElement2.RowIndex = 1;
            tileViewItemElement2.Text = "colName";
            tileViewItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement3.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI", 9F);
            tileViewItemElement3.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement3.Column = this.colPrice;
            tileViewItemElement3.RowIndex = 2;
            tileViewItemElement3.Text = "colPrice";
            tileViewItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.tileMenu.TileTemplate.Add(tileViewItemElement1);
            this.tileMenu.TileTemplate.Add(tileViewItemElement2);
            this.tileMenu.TileTemplate.Add(tileViewItemElement3);
            this.tileMenu.ItemClick += new DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventHandler(this.tileMenu_ItemClick);
            this.tileMenu.Click += new System.EventHandler(this.tileMenu_Click);
            // 
            // lblAllMenu
            // 
            this.lblAllMenu.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAllMenu.Appearance.Options.UseFont = true;
            this.lblAllMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAllMenu.Location = new System.Drawing.Point(10, 10);
            this.lblAllMenu.Name = "lblAllMenu";
            this.lblAllMenu.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.lblAllMenu.Size = new System.Drawing.Size(63, 28);
            this.lblAllMenu.TabIndex = 1;
            this.lblAllMenu.Text = "All Menu";
            // 
            // panelCategory
            // 
            this.panelCategory.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelCategory.Controls.Add(this.categoryButtonsPanel);
            this.panelCategory.Controls.Add(this.lblMenuCategory);
            this.panelCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCategory.Location = new System.Drawing.Point(10, 10);
            this.panelCategory.Name = "panelCategory";
            this.panelCategory.Padding = new System.Windows.Forms.Padding(10);
            this.panelCategory.Size = new System.Drawing.Size(730, 110);
            this.panelCategory.TabIndex = 1;
            // 
            // categoryButtonsPanel
            // 
            this.categoryButtonsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoryButtonsPanel.Location = new System.Drawing.Point(10, 38);
            this.categoryButtonsPanel.Name = "categoryButtonsPanel";
            this.categoryButtonsPanel.Size = new System.Drawing.Size(710, 62);
            this.categoryButtonsPanel.TabIndex = 0;
            this.categoryButtonsPanel.WrapContents = false;
            // 
            // lblMenuCategory
            // 
            this.lblMenuCategory.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMenuCategory.Appearance.Options.UseFont = true;
            this.lblMenuCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMenuCategory.Location = new System.Drawing.Point(10, 10);
            this.lblMenuCategory.Name = "lblMenuCategory";
            this.lblMenuCategory.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.lblMenuCategory.Size = new System.Drawing.Size(107, 28);
            this.lblMenuCategory.TabIndex = 1;
            this.lblMenuCategory.Text = "Menu Category";
            // 
            // panelRight
            // 
            this.panelRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelRight.Controls.Add(this.panelOrderGrid);
            this.panelRight.Controls.Add(this.panelOrderFooter);
            this.panelRight.Controls.Add(this.panelOrderHeader);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(760, 10);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(10);
            this.panelRight.Size = new System.Drawing.Size(488, 570);
            this.panelRight.TabIndex = 0;
            // 
            // panelOrderGrid
            // 
            this.panelOrderGrid.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelOrderGrid.Controls.Add(this.gridOrder);
            this.panelOrderGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOrderGrid.Location = new System.Drawing.Point(10, 110);
            this.panelOrderGrid.Name = "panelOrderGrid";
            this.panelOrderGrid.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.panelOrderGrid.Size = new System.Drawing.Size(468, 309);
            this.panelOrderGrid.TabIndex = 0;
            // 
            // gridOrder
            // 
            this.gridOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridOrder.Location = new System.Drawing.Point(10, 5);
            this.gridOrder.MainView = this.gvOrder;
            this.gridOrder.Name = "gridOrder";
            this.gridOrder.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnmainDecrease,
            this.btnCancel});
            this.gridOrder.Size = new System.Drawing.Size(448, 299);
            this.gridOrder.TabIndex = 0;
            this.gridOrder.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvOrder});
            // 
            // gvOrder
            // 
            this.gvOrder.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colItem,
            this.colQty,
            this.colUnitPrice,
            this.colAmount,
            this.gridColumn1,
            this.gridColumn2});
            this.gvOrder.GridControl = this.gridOrder;
            this.gvOrder.Name = "gvOrder";
            this.gvOrder.OptionsView.ShowGroupPanel = false;
            this.gvOrder.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvOrder_CellValueChanged);
            // 
            // colItem
            // 
            this.colItem.Caption = "Item";
            this.colItem.FieldName = "Item";
            this.colItem.Name = "colItem";
            this.colItem.Visible = true;
            this.colItem.VisibleIndex = 0;
            // 
            // colQty
            // 
            this.colQty.Caption = "Qty";
            this.colQty.FieldName = "Qty";
            this.colQty.Name = "colQty";
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 1;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.Caption = "Price";
            this.colUnitPrice.FieldName = "Price";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.Visible = true;
            this.colUnitPrice.VisibleIndex = 2;
            // 
            // colAmount
            // 
            this.colAmount.Caption = "Amount";
            this.colAmount.FieldName = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 3;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "minus";
            this.gridColumn1.ColumnEdit = this.btnmainDecrease;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            // 
            // btnmainDecrease
            // 
            this.btnmainDecrease.AutoHeight = false;
            editorButtonImageOptions1.Image = global::unt_bingoo.Properties.Resources.Minus1;
            this.btnmainDecrease.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnmainDecrease.Name = "btnmainDecrease";
            this.btnmainDecrease.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnmainDecrease.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnmainDecrease_ButtonClick);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Cancel";
            this.gridColumn2.ColumnEdit = this.btnCancel;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoHeight = false;
            editorButtonImageOptions2.Image = global::unt_bingoo.Properties.Resources.Cancel16;
            this.btnCancel.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnCancel.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnCancel_ButtonClick);
            // 
            // panelOrderFooter
            // 
            this.panelOrderFooter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelOrderFooter.Controls.Add(this.lbldis);
            this.panelOrderFooter.Controls.Add(this.lbltotals);
            this.panelOrderFooter.Controls.Add(this.lblsub);
            this.panelOrderFooter.Controls.Add(this.lblSubTotalText);
            this.panelOrderFooter.Controls.Add(this.lblSubTotal);
            this.panelOrderFooter.Controls.Add(this.lblDiscountText);
            this.panelOrderFooter.Controls.Add(this.lblDiscount);
            this.panelOrderFooter.Controls.Add(this.lblTotalText);
            this.panelOrderFooter.Controls.Add(this.lblTotal);
            this.panelOrderFooter.Controls.Add(this.btnContinuePayment);
            this.panelOrderFooter.Controls.Add(this.btnClearOrder);
            this.panelOrderFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelOrderFooter.Location = new System.Drawing.Point(10, 419);
            this.panelOrderFooter.Name = "panelOrderFooter";
            this.panelOrderFooter.Padding = new System.Windows.Forms.Padding(10);
            this.panelOrderFooter.Size = new System.Drawing.Size(468, 141);
            this.panelOrderFooter.TabIndex = 1;
            // 
            // lbldis
            // 
            this.lbldis.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lbldis.Appearance.Options.UseFont = true;
            this.lbldis.Location = new System.Drawing.Point(74, 35);
            this.lbldis.Name = "lbldis";
            this.lbldis.Size = new System.Drawing.Size(0, 15);
            this.lbldis.TabIndex = 10;
            // 
            // lbltotals
            // 
            this.lbltotals.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lbltotals.Appearance.Options.UseFont = true;
            this.lbltotals.Location = new System.Drawing.Point(77, 65);
            this.lbltotals.Name = "lbltotals";
            this.lbltotals.Size = new System.Drawing.Size(0, 20);
            this.lbltotals.TabIndex = 9;
            // 
            // lblsub
            // 
            this.lblsub.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblsub.Appearance.Options.UseFont = true;
            this.lblsub.Location = new System.Drawing.Point(74, 10);
            this.lblsub.Name = "lblsub";
            this.lblsub.Size = new System.Drawing.Size(0, 15);
            this.lblsub.TabIndex = 8;
            // 
            // lblSubTotalText
            // 
            this.lblSubTotalText.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubTotalText.Appearance.Options.UseFont = true;
            this.lblSubTotalText.Location = new System.Drawing.Point(10, 10);
            this.lblSubTotalText.Name = "lblSubTotalText";
            this.lblSubTotalText.Size = new System.Drawing.Size(53, 15);
            this.lblSubTotalText.TabIndex = 0;
            this.lblSubTotalText.Text = "Sub total :";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubTotal.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSubTotal.Appearance.Options.UseFont = true;
            this.lblSubTotal.Location = new System.Drawing.Point(365, 10);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(24, 15);
            this.lblSubTotal.TabIndex = 1;
            this.lblSubTotal.Text = "0.00";
            // 
            // lblDiscountText
            // 
            this.lblDiscountText.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDiscountText.Appearance.Options.UseFont = true;
            this.lblDiscountText.Location = new System.Drawing.Point(10, 35);
            this.lblDiscountText.Name = "lblDiscountText";
            this.lblDiscountText.Size = new System.Drawing.Size(53, 15);
            this.lblDiscountText.TabIndex = 2;
            this.lblDiscountText.Text = "Discount :";
            // 
            // lblDiscount
            // 
            this.lblDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiscount.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDiscount.Appearance.Options.UseFont = true;
            this.lblDiscount.Location = new System.Drawing.Point(365, 35);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(24, 15);
            this.lblDiscount.TabIndex = 3;
            this.lblDiscount.Text = "0.00";
            // 
            // lblTotalText
            // 
            this.lblTotalText.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalText.Appearance.Options.UseFont = true;
            this.lblTotalText.Location = new System.Drawing.Point(10, 65);
            this.lblTotalText.Name = "lblTotalText";
            this.lblTotalText.Size = new System.Drawing.Size(44, 20);
            this.lblTotalText.TabIndex = 4;
            this.lblTotalText.Text = "Total :";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Appearance.Options.UseFont = true;
            this.lblTotal.Location = new System.Drawing.Point(365, 65);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(31, 20);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "0.00";
            // 
            // btnContinuePayment
            // 
            this.btnContinuePayment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContinuePayment.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnContinuePayment.Appearance.Options.UseFont = true;
            this.btnContinuePayment.Location = new System.Drawing.Point(10, 91);
            this.btnContinuePayment.Name = "btnContinuePayment";
            this.btnContinuePayment.Size = new System.Drawing.Size(448, 38);
            this.btnContinuePayment.TabIndex = 6;
            this.btnContinuePayment.Text = "Continue Payment";
            this.btnContinuePayment.Click += new System.EventHandler(this.btnContinuePayment_Click);
            // 
            // btnClearOrder
            // 
            this.btnClearOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearOrder.Location = new System.Drawing.Point(464, 91);
            this.btnClearOrder.Name = "btnClearOrder";
            this.btnClearOrder.Size = new System.Drawing.Size(0, 0);
            this.btnClearOrder.TabIndex = 7;
            this.btnClearOrder.Text = "Clear Order";
            // 
            // panelOrderHeader
            // 
            this.panelOrderHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelOrderHeader.Controls.Add(this.lblOrderTitle);
            this.panelOrderHeader.Controls.Add(this.lblOrderNo);
            this.panelOrderHeader.Controls.Add(this.rdoOrderType);
            this.panelOrderHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOrderHeader.Location = new System.Drawing.Point(10, 10);
            this.panelOrderHeader.Name = "panelOrderHeader";
            this.panelOrderHeader.Padding = new System.Windows.Forms.Padding(10);
            this.panelOrderHeader.Size = new System.Drawing.Size(468, 100);
            this.panelOrderHeader.TabIndex = 2;
            // 
            // lblOrderTitle
            // 
            this.lblOrderTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblOrderTitle.Appearance.Options.UseFont = true;
            this.lblOrderTitle.Location = new System.Drawing.Point(10, 10);
            this.lblOrderTitle.Name = "lblOrderTitle";
            this.lblOrderTitle.Size = new System.Drawing.Size(62, 20);
            this.lblOrderTitle.TabIndex = 0;
            this.lblOrderTitle.Text = "Order #1";
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOrderNo.Appearance.Options.UseFont = true;
            this.lblOrderNo.Location = new System.Drawing.Point(10, 40);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(99, 15);
            this.lblOrderNo.TabIndex = 1;
            this.lblOrderNo.Text = "Table / Invoice No.";
            // 
            // rdoOrderType
            // 
            this.rdoOrderType.Location = new System.Drawing.Point(260, 15);
            this.rdoOrderType.Name = "rdoOrderType";
            this.rdoOrderType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rdoOrderType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("DineIn", "Dine in"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("TakeAway", "Take away")});
            this.rdoOrderType.Size = new System.Drawing.Size(198, 60);
            this.rdoOrderType.TabIndex = 2;
            // 
            // guiforSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 590);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Name = "guiforSale";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POS - Sales";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.guiforSale_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelLeft)).EndInit();
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelMenu)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelCategory)).EndInit();
            this.panelCategory.ResumeLayout(false);
            this.panelCategory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelRight)).EndInit();
            this.panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelOrderGrid)).EndInit();
            this.panelOrderGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnmainDecrease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelOrderFooter)).EndInit();
            this.panelOrderFooter.ResumeLayout(false);
            this.panelOrderFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelOrderHeader)).EndInit();
            this.panelOrderHeader.ResumeLayout(false);
            this.panelOrderHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdoOrderType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
