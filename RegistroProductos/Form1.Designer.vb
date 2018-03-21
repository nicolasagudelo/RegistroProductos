<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPageRegistrarProducto = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DTPFechaLimite = New System.Windows.Forms.DateTimePicker()
        Me.LblFechaLimite = New System.Windows.Forms.Label()
        Me.CmbBxTipoProducto = New System.Windows.Forms.ComboBox()
        Me.LblTipoProducto = New System.Windows.Forms.Label()
        Me.CmbBxClientes = New System.Windows.Forms.ComboBox()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.LblNumeroProducto = New System.Windows.Forms.Label()
        Me.TxtBxProductoID = New System.Windows.Forms.TextBox()
        Me.DGVProductosSinRevisar = New System.Windows.Forms.DataGridView()
        Me.BtnRegistrarProducto = New System.Windows.Forms.Button()
        Me.BtnModificarRegistro = New System.Windows.Forms.Button()
        Me.TabPageProductoLimite = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DTPFechaLimite2 = New System.Windows.Forms.DateTimePicker()
        Me.LblFechaLimite2 = New System.Windows.Forms.Label()
        Me.CmbBxProducto2 = New System.Windows.Forms.ComboBox()
        Me.LblProducto2 = New System.Windows.Forms.Label()
        Me.CmbBxCliente2 = New System.Windows.Forms.ComboBox()
        Me.LblCliente2 = New System.Windows.Forms.Label()
        Me.LblNumeroProducto2 = New System.Windows.Forms.Label()
        Me.TxtBxNumeroProducto2 = New System.Windows.Forms.TextBox()
        Me.DGVProductosLimite = New System.Windows.Forms.DataGridView()
        Me.BtnModificarRegistroLimite = New System.Windows.Forms.Button()
        Me.TabPageTransito = New System.Windows.Forms.TabPage()
        Me.DGVTransito = New System.Windows.Forms.DataGridView()
        Me.TabPageProductosRevisados = New System.Windows.Forms.TabPage()
        Me.DGVProductosRevisados = New System.Windows.Forms.DataGridView()
        Me.TabPageAdmin = New System.Windows.Forms.TabPage()
        Me.GrpBxAdmin2 = New System.Windows.Forms.GroupBox()
        Me.CmbBxEsAdmin = New System.Windows.Forms.ComboBox()
        Me.LblValorAdmin = New System.Windows.Forms.Label()
        Me.Intervalo = New System.Windows.Forms.NumericUpDown()
        Me.CmbBx1GrpBxAdmin2 = New System.Windows.Forms.ComboBox()
        Me.CmbBx2GrpBxAdmin2 = New System.Windows.Forms.ComboBox()
        Me.TxtBx3GrpBxAdmin2 = New System.Windows.Forms.TextBox()
        Me.Lbl3GrpBxAdmin2 = New System.Windows.Forms.Label()
        Me.BtnAceptarGrpBxAdmin2 = New System.Windows.Forms.Button()
        Me.TxtBx2GrpBxAdmin2 = New System.Windows.Forms.TextBox()
        Me.TxtBx1GrpBxAdmin2 = New System.Windows.Forms.TextBox()
        Me.Lbl2GrpBxAdmin2 = New System.Windows.Forms.Label()
        Me.Lbl1GrpBxAdmin2 = New System.Windows.Forms.Label()
        Me.GrpBxAdmin = New System.Windows.Forms.GroupBox()
        Me.BtnEliminarRegistro = New System.Windows.Forms.Button()
        Me.BtnModificarRegistroAdmin = New System.Windows.Forms.Button()
        Me.BtnNuevoRegistro = New System.Windows.Forms.Button()
        Me.CmbBxTablas = New System.Windows.Forms.ComboBox()
        Me.DGVAdmin = New System.Windows.Forms.DataGridView()
        Me.LblUsuario = New System.Windows.Forms.Label()
        Me.BtnDesconectar = New System.Windows.Forms.Button()
        Me.LblCambiarContraseña = New System.Windows.Forms.Label()
        Me.LblEsAdmin = New System.Windows.Forms.Label()
        Me.GrpBxTipoSesion = New System.Windows.Forms.GroupBox()
        Me.RBAnalista = New System.Windows.Forms.RadioButton()
        Me.RBAdmin = New System.Windows.Forms.RadioButton()
        Me.TabControl1.SuspendLayout()
        Me.TabPageRegistrarProducto.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DGVProductosSinRevisar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageProductoLimite.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DGVProductosLimite, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageTransito.SuspendLayout()
        CType(Me.DGVTransito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageProductosRevisados.SuspendLayout()
        CType(Me.DGVProductosRevisados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageAdmin.SuspendLayout()
        Me.GrpBxAdmin2.SuspendLayout()
        CType(Me.Intervalo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpBxAdmin.SuspendLayout()
        CType(Me.DGVAdmin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpBxTipoSesion.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPageRegistrarProducto)
        Me.TabControl1.Controls.Add(Me.TabPageProductoLimite)
        Me.TabControl1.Controls.Add(Me.TabPageTransito)
        Me.TabControl1.Controls.Add(Me.TabPageProductosRevisados)
        Me.TabControl1.Controls.Add(Me.TabPageAdmin)
        Me.TabControl1.Location = New System.Drawing.Point(0, 24)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(933, 460)
        Me.TabControl1.TabIndex = 0
        '
        'TabPageRegistrarProducto
        '
        Me.TabPageRegistrarProducto.BackColor = System.Drawing.SystemColors.Control
        Me.TabPageRegistrarProducto.Controls.Add(Me.Panel1)
        Me.TabPageRegistrarProducto.Controls.Add(Me.DGVProductosSinRevisar)
        Me.TabPageRegistrarProducto.Controls.Add(Me.BtnRegistrarProducto)
        Me.TabPageRegistrarProducto.Controls.Add(Me.BtnModificarRegistro)
        Me.TabPageRegistrarProducto.Location = New System.Drawing.Point(4, 22)
        Me.TabPageRegistrarProducto.Name = "TabPageRegistrarProducto"
        Me.TabPageRegistrarProducto.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageRegistrarProducto.Size = New System.Drawing.Size(925, 434)
        Me.TabPageRegistrarProducto.TabIndex = 0
        Me.TabPageRegistrarProducto.Text = "Registrar Producto"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.DTPFechaLimite)
        Me.Panel1.Controls.Add(Me.LblFechaLimite)
        Me.Panel1.Controls.Add(Me.CmbBxTipoProducto)
        Me.Panel1.Controls.Add(Me.LblTipoProducto)
        Me.Panel1.Controls.Add(Me.CmbBxClientes)
        Me.Panel1.Controls.Add(Me.LblCliente)
        Me.Panel1.Controls.Add(Me.LblNumeroProducto)
        Me.Panel1.Controls.Add(Me.TxtBxProductoID)
        Me.Panel1.Location = New System.Drawing.Point(8, 291)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(787, 137)
        Me.Panel1.TabIndex = 1
        '
        'DTPFechaLimite
        '
        Me.DTPFechaLimite.Enabled = False
        Me.DTPFechaLimite.Location = New System.Drawing.Point(258, 40)
        Me.DTPFechaLimite.Name = "DTPFechaLimite"
        Me.DTPFechaLimite.Size = New System.Drawing.Size(217, 20)
        Me.DTPFechaLimite.TabIndex = 13
        Me.DTPFechaLimite.Visible = False
        '
        'LblFechaLimite
        '
        Me.LblFechaLimite.AutoSize = True
        Me.LblFechaLimite.Enabled = False
        Me.LblFechaLimite.Location = New System.Drawing.Point(255, 24)
        Me.LblFechaLimite.Name = "LblFechaLimite"
        Me.LblFechaLimite.Size = New System.Drawing.Size(70, 13)
        Me.LblFechaLimite.TabIndex = 12
        Me.LblFechaLimite.Text = "Fecha Limite:"
        Me.LblFechaLimite.Visible = False
        '
        'CmbBxTipoProducto
        '
        Me.CmbBxTipoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBxTipoProducto.Enabled = False
        Me.CmbBxTipoProducto.FormattingEnabled = True
        Me.CmbBxTipoProducto.Location = New System.Drawing.Point(258, 87)
        Me.CmbBxTipoProducto.Name = "CmbBxTipoProducto"
        Me.CmbBxTipoProducto.Size = New System.Drawing.Size(217, 21)
        Me.CmbBxTipoProducto.TabIndex = 6
        '
        'LblTipoProducto
        '
        Me.LblTipoProducto.AutoSize = True
        Me.LblTipoProducto.Location = New System.Drawing.Point(255, 71)
        Me.LblTipoProducto.Name = "LblTipoProducto"
        Me.LblTipoProducto.Size = New System.Drawing.Size(53, 13)
        Me.LblTipoProducto.TabIndex = 4
        Me.LblTipoProducto.Text = "Producto:"
        '
        'CmbBxClientes
        '
        Me.CmbBxClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBxClientes.FormattingEnabled = True
        Me.CmbBxClientes.IntegralHeight = False
        Me.CmbBxClientes.Location = New System.Drawing.Point(13, 87)
        Me.CmbBxClientes.Name = "CmbBxClientes"
        Me.CmbBxClientes.Size = New System.Drawing.Size(212, 21)
        Me.CmbBxClientes.TabIndex = 3
        '
        'LblCliente
        '
        Me.LblCliente.AutoSize = True
        Me.LblCliente.Location = New System.Drawing.Point(10, 71)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(42, 13)
        Me.LblCliente.TabIndex = 2
        Me.LblCliente.Text = "Cliente:"
        '
        'LblNumeroProducto
        '
        Me.LblNumeroProducto.AutoSize = True
        Me.LblNumeroProducto.Location = New System.Drawing.Point(10, 11)
        Me.LblNumeroProducto.Name = "LblNumeroProducto"
        Me.LblNumeroProducto.Size = New System.Drawing.Size(91, 26)
        Me.LblNumeroProducto.TabIndex = 1
        Me.LblNumeroProducto.Text = "Identificador de la" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "muestra:"
        '
        'TxtBxProductoID
        '
        Me.TxtBxProductoID.Location = New System.Drawing.Point(13, 40)
        Me.TxtBxProductoID.Name = "TxtBxProductoID"
        Me.TxtBxProductoID.ReadOnly = True
        Me.TxtBxProductoID.Size = New System.Drawing.Size(212, 20)
        Me.TxtBxProductoID.TabIndex = 0
        '
        'DGVProductosSinRevisar
        '
        Me.DGVProductosSinRevisar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGVProductosSinRevisar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGVProductosSinRevisar.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DGVProductosSinRevisar.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGVProductosSinRevisar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVProductosSinRevisar.Cursor = System.Windows.Forms.Cursors.Default
        Me.DGVProductosSinRevisar.Location = New System.Drawing.Point(3, 3)
        Me.DGVProductosSinRevisar.Name = "DGVProductosSinRevisar"
        Me.DGVProductosSinRevisar.Size = New System.Drawing.Size(916, 278)
        Me.DGVProductosSinRevisar.TabIndex = 0
        '
        'BtnRegistrarProducto
        '
        Me.BtnRegistrarProducto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRegistrarProducto.Location = New System.Drawing.Point(829, 365)
        Me.BtnRegistrarProducto.Name = "BtnRegistrarProducto"
        Me.BtnRegistrarProducto.Size = New System.Drawing.Size(90, 45)
        Me.BtnRegistrarProducto.TabIndex = 5
        Me.BtnRegistrarProducto.Text = "Registrar Producto"
        Me.BtnRegistrarProducto.UseVisualStyleBackColor = True
        '
        'BtnModificarRegistro
        '
        Me.BtnModificarRegistro.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificarRegistro.Enabled = False
        Me.BtnModificarRegistro.Location = New System.Drawing.Point(829, 365)
        Me.BtnModificarRegistro.Name = "BtnModificarRegistro"
        Me.BtnModificarRegistro.Size = New System.Drawing.Size(90, 45)
        Me.BtnModificarRegistro.TabIndex = 10
        Me.BtnModificarRegistro.Text = "Modificar Registro"
        Me.BtnModificarRegistro.UseVisualStyleBackColor = True
        Me.BtnModificarRegistro.Visible = False
        '
        'TabPageProductoLimite
        '
        Me.TabPageProductoLimite.BackColor = System.Drawing.SystemColors.Control
        Me.TabPageProductoLimite.Controls.Add(Me.Panel2)
        Me.TabPageProductoLimite.Controls.Add(Me.DGVProductosLimite)
        Me.TabPageProductoLimite.Controls.Add(Me.BtnModificarRegistroLimite)
        Me.TabPageProductoLimite.Location = New System.Drawing.Point(4, 22)
        Me.TabPageProductoLimite.Name = "TabPageProductoLimite"
        Me.TabPageProductoLimite.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageProductoLimite.Size = New System.Drawing.Size(925, 434)
        Me.TabPageProductoLimite.TabIndex = 1
        Me.TabPageProductoLimite.Text = "Productos Limite"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.DTPFechaLimite2)
        Me.Panel2.Controls.Add(Me.LblFechaLimite2)
        Me.Panel2.Controls.Add(Me.CmbBxProducto2)
        Me.Panel2.Controls.Add(Me.LblProducto2)
        Me.Panel2.Controls.Add(Me.CmbBxCliente2)
        Me.Panel2.Controls.Add(Me.LblCliente2)
        Me.Panel2.Controls.Add(Me.LblNumeroProducto2)
        Me.Panel2.Controls.Add(Me.TxtBxNumeroProducto2)
        Me.Panel2.Location = New System.Drawing.Point(8, 291)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(787, 137)
        Me.Panel2.TabIndex = 3
        '
        'DTPFechaLimite2
        '
        Me.DTPFechaLimite2.Enabled = False
        Me.DTPFechaLimite2.Location = New System.Drawing.Point(258, 40)
        Me.DTPFechaLimite2.Name = "DTPFechaLimite2"
        Me.DTPFechaLimite2.Size = New System.Drawing.Size(217, 20)
        Me.DTPFechaLimite2.TabIndex = 13
        Me.DTPFechaLimite2.Visible = False
        '
        'LblFechaLimite2
        '
        Me.LblFechaLimite2.AutoSize = True
        Me.LblFechaLimite2.Enabled = False
        Me.LblFechaLimite2.Location = New System.Drawing.Point(255, 24)
        Me.LblFechaLimite2.Name = "LblFechaLimite2"
        Me.LblFechaLimite2.Size = New System.Drawing.Size(70, 13)
        Me.LblFechaLimite2.TabIndex = 12
        Me.LblFechaLimite2.Text = "Fecha Limite:"
        Me.LblFechaLimite2.Visible = False
        '
        'CmbBxProducto2
        '
        Me.CmbBxProducto2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBxProducto2.Enabled = False
        Me.CmbBxProducto2.FormattingEnabled = True
        Me.CmbBxProducto2.Location = New System.Drawing.Point(258, 87)
        Me.CmbBxProducto2.Name = "CmbBxProducto2"
        Me.CmbBxProducto2.Size = New System.Drawing.Size(217, 21)
        Me.CmbBxProducto2.TabIndex = 6
        '
        'LblProducto2
        '
        Me.LblProducto2.AutoSize = True
        Me.LblProducto2.Location = New System.Drawing.Point(255, 71)
        Me.LblProducto2.Name = "LblProducto2"
        Me.LblProducto2.Size = New System.Drawing.Size(53, 13)
        Me.LblProducto2.TabIndex = 4
        Me.LblProducto2.Text = "Producto:"
        '
        'CmbBxCliente2
        '
        Me.CmbBxCliente2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBxCliente2.FormattingEnabled = True
        Me.CmbBxCliente2.IntegralHeight = False
        Me.CmbBxCliente2.Location = New System.Drawing.Point(13, 87)
        Me.CmbBxCliente2.Name = "CmbBxCliente2"
        Me.CmbBxCliente2.Size = New System.Drawing.Size(212, 21)
        Me.CmbBxCliente2.TabIndex = 3
        '
        'LblCliente2
        '
        Me.LblCliente2.AutoSize = True
        Me.LblCliente2.Location = New System.Drawing.Point(10, 71)
        Me.LblCliente2.Name = "LblCliente2"
        Me.LblCliente2.Size = New System.Drawing.Size(42, 13)
        Me.LblCliente2.TabIndex = 2
        Me.LblCliente2.Text = "Cliente:"
        '
        'LblNumeroProducto2
        '
        Me.LblNumeroProducto2.AutoSize = True
        Me.LblNumeroProducto2.Location = New System.Drawing.Point(10, 11)
        Me.LblNumeroProducto2.Name = "LblNumeroProducto2"
        Me.LblNumeroProducto2.Size = New System.Drawing.Size(94, 26)
        Me.LblNumeroProducto2.TabIndex = 1
        Me.LblNumeroProducto2.Text = "Identificador de la " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "muestra:"
        '
        'TxtBxNumeroProducto2
        '
        Me.TxtBxNumeroProducto2.Location = New System.Drawing.Point(13, 40)
        Me.TxtBxNumeroProducto2.Name = "TxtBxNumeroProducto2"
        Me.TxtBxNumeroProducto2.Size = New System.Drawing.Size(212, 20)
        Me.TxtBxNumeroProducto2.TabIndex = 0
        '
        'DGVProductosLimite
        '
        Me.DGVProductosLimite.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGVProductosLimite.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGVProductosLimite.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DGVProductosLimite.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGVProductosLimite.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVProductosLimite.Cursor = System.Windows.Forms.Cursors.Default
        Me.DGVProductosLimite.Location = New System.Drawing.Point(3, 3)
        Me.DGVProductosLimite.Name = "DGVProductosLimite"
        Me.DGVProductosLimite.Size = New System.Drawing.Size(916, 254)
        Me.DGVProductosLimite.TabIndex = 2
        '
        'BtnModificarRegistroLimite
        '
        Me.BtnModificarRegistroLimite.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModificarRegistroLimite.Enabled = False
        Me.BtnModificarRegistroLimite.Location = New System.Drawing.Point(829, 365)
        Me.BtnModificarRegistroLimite.Name = "BtnModificarRegistroLimite"
        Me.BtnModificarRegistroLimite.Size = New System.Drawing.Size(90, 45)
        Me.BtnModificarRegistroLimite.TabIndex = 10
        Me.BtnModificarRegistroLimite.Text = "Modificar Registro"
        Me.BtnModificarRegistroLimite.UseVisualStyleBackColor = True
        Me.BtnModificarRegistroLimite.Visible = False
        '
        'TabPageTransito
        '
        Me.TabPageTransito.BackColor = System.Drawing.SystemColors.Control
        Me.TabPageTransito.Controls.Add(Me.DGVTransito)
        Me.TabPageTransito.Location = New System.Drawing.Point(4, 22)
        Me.TabPageTransito.Name = "TabPageTransito"
        Me.TabPageTransito.Size = New System.Drawing.Size(925, 434)
        Me.TabPageTransito.TabIndex = 4
        Me.TabPageTransito.Text = "Productos En Transito"
        '
        'DGVTransito
        '
        Me.DGVTransito.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGVTransito.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGVTransito.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DGVTransito.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGVTransito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVTransito.Cursor = System.Windows.Forms.Cursors.Default
        Me.DGVTransito.Location = New System.Drawing.Point(3, 3)
        Me.DGVTransito.Name = "DGVTransito"
        Me.DGVTransito.Size = New System.Drawing.Size(916, 421)
        Me.DGVTransito.TabIndex = 1
        '
        'TabPageProductosRevisados
        '
        Me.TabPageProductosRevisados.BackColor = System.Drawing.SystemColors.Control
        Me.TabPageProductosRevisados.Controls.Add(Me.DGVProductosRevisados)
        Me.TabPageProductosRevisados.Location = New System.Drawing.Point(4, 22)
        Me.TabPageProductosRevisados.Name = "TabPageProductosRevisados"
        Me.TabPageProductosRevisados.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageProductosRevisados.Size = New System.Drawing.Size(925, 434)
        Me.TabPageProductosRevisados.TabIndex = 3
        Me.TabPageProductosRevisados.Text = "Productos Revisados"
        '
        'DGVProductosRevisados
        '
        Me.DGVProductosRevisados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGVProductosRevisados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGVProductosRevisados.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DGVProductosRevisados.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGVProductosRevisados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVProductosRevisados.Cursor = System.Windows.Forms.Cursors.Default
        Me.DGVProductosRevisados.Location = New System.Drawing.Point(3, 6)
        Me.DGVProductosRevisados.Name = "DGVProductosRevisados"
        Me.DGVProductosRevisados.Size = New System.Drawing.Size(916, 406)
        Me.DGVProductosRevisados.TabIndex = 7
        '
        'TabPageAdmin
        '
        Me.TabPageAdmin.BackColor = System.Drawing.SystemColors.Control
        Me.TabPageAdmin.Controls.Add(Me.GrpBxAdmin2)
        Me.TabPageAdmin.Controls.Add(Me.GrpBxAdmin)
        Me.TabPageAdmin.Controls.Add(Me.CmbBxTablas)
        Me.TabPageAdmin.Controls.Add(Me.DGVAdmin)
        Me.TabPageAdmin.Location = New System.Drawing.Point(4, 22)
        Me.TabPageAdmin.Name = "TabPageAdmin"
        Me.TabPageAdmin.Size = New System.Drawing.Size(925, 434)
        Me.TabPageAdmin.TabIndex = 2
        Me.TabPageAdmin.Text = "Administrador"
        '
        'GrpBxAdmin2
        '
        Me.GrpBxAdmin2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpBxAdmin2.Controls.Add(Me.CmbBxEsAdmin)
        Me.GrpBxAdmin2.Controls.Add(Me.LblValorAdmin)
        Me.GrpBxAdmin2.Controls.Add(Me.Intervalo)
        Me.GrpBxAdmin2.Controls.Add(Me.CmbBx1GrpBxAdmin2)
        Me.GrpBxAdmin2.Controls.Add(Me.CmbBx2GrpBxAdmin2)
        Me.GrpBxAdmin2.Controls.Add(Me.TxtBx3GrpBxAdmin2)
        Me.GrpBxAdmin2.Controls.Add(Me.Lbl3GrpBxAdmin2)
        Me.GrpBxAdmin2.Controls.Add(Me.BtnAceptarGrpBxAdmin2)
        Me.GrpBxAdmin2.Controls.Add(Me.TxtBx2GrpBxAdmin2)
        Me.GrpBxAdmin2.Controls.Add(Me.TxtBx1GrpBxAdmin2)
        Me.GrpBxAdmin2.Controls.Add(Me.Lbl2GrpBxAdmin2)
        Me.GrpBxAdmin2.Controls.Add(Me.Lbl1GrpBxAdmin2)
        Me.GrpBxAdmin2.Location = New System.Drawing.Point(514, 317)
        Me.GrpBxAdmin2.Name = "GrpBxAdmin2"
        Me.GrpBxAdmin2.Size = New System.Drawing.Size(393, 100)
        Me.GrpBxAdmin2.TabIndex = 7
        Me.GrpBxAdmin2.TabStop = False
        '
        'CmbBxEsAdmin
        '
        Me.CmbBxEsAdmin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBxEsAdmin.FormattingEnabled = True
        Me.CmbBxEsAdmin.Location = New System.Drawing.Point(141, 72)
        Me.CmbBxEsAdmin.Name = "CmbBxEsAdmin"
        Me.CmbBxEsAdmin.Size = New System.Drawing.Size(129, 21)
        Me.CmbBxEsAdmin.TabIndex = 13
        '
        'LblValorAdmin
        '
        Me.LblValorAdmin.AutoSize = True
        Me.LblValorAdmin.Location = New System.Drawing.Point(138, 56)
        Me.LblValorAdmin.Name = "LblValorAdmin"
        Me.LblValorAdmin.Size = New System.Drawing.Size(96, 13)
        Me.LblValorAdmin.TabIndex = 12
        Me.LblValorAdmin.Text = "¿Es administrador?"
        '
        'Intervalo
        '
        Me.Intervalo.Location = New System.Drawing.Point(6, 72)
        Me.Intervalo.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.Intervalo.Name = "Intervalo"
        Me.Intervalo.Size = New System.Drawing.Size(129, 20)
        Me.Intervalo.TabIndex = 11
        Me.Intervalo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Intervalo.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'CmbBx1GrpBxAdmin2
        '
        Me.CmbBx1GrpBxAdmin2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBx1GrpBxAdmin2.FormattingEnabled = True
        Me.CmbBx1GrpBxAdmin2.Location = New System.Drawing.Point(6, 31)
        Me.CmbBx1GrpBxAdmin2.Name = "CmbBx1GrpBxAdmin2"
        Me.CmbBx1GrpBxAdmin2.Size = New System.Drawing.Size(129, 21)
        Me.CmbBx1GrpBxAdmin2.TabIndex = 7
        '
        'CmbBx2GrpBxAdmin2
        '
        Me.CmbBx2GrpBxAdmin2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBx2GrpBxAdmin2.FormattingEnabled = True
        Me.CmbBx2GrpBxAdmin2.Location = New System.Drawing.Point(6, 71)
        Me.CmbBx2GrpBxAdmin2.Name = "CmbBx2GrpBxAdmin2"
        Me.CmbBx2GrpBxAdmin2.Size = New System.Drawing.Size(129, 21)
        Me.CmbBx2GrpBxAdmin2.TabIndex = 8
        '
        'TxtBx3GrpBxAdmin2
        '
        Me.TxtBx3GrpBxAdmin2.Location = New System.Drawing.Point(141, 32)
        Me.TxtBx3GrpBxAdmin2.Name = "TxtBx3GrpBxAdmin2"
        Me.TxtBx3GrpBxAdmin2.Size = New System.Drawing.Size(124, 20)
        Me.TxtBx3GrpBxAdmin2.TabIndex = 10
        '
        'Lbl3GrpBxAdmin2
        '
        Me.Lbl3GrpBxAdmin2.AutoSize = True
        Me.Lbl3GrpBxAdmin2.Location = New System.Drawing.Point(138, 16)
        Me.Lbl3GrpBxAdmin2.Name = "Lbl3GrpBxAdmin2"
        Me.Lbl3GrpBxAdmin2.Size = New System.Drawing.Size(39, 13)
        Me.Lbl3GrpBxAdmin2.TabIndex = 9
        Me.Lbl3GrpBxAdmin2.Text = "Label1"
        '
        'BtnAceptarGrpBxAdmin2
        '
        Me.BtnAceptarGrpBxAdmin2.Location = New System.Drawing.Point(313, 55)
        Me.BtnAceptarGrpBxAdmin2.Name = "BtnAceptarGrpBxAdmin2"
        Me.BtnAceptarGrpBxAdmin2.Size = New System.Drawing.Size(74, 39)
        Me.BtnAceptarGrpBxAdmin2.TabIndex = 8
        Me.BtnAceptarGrpBxAdmin2.Text = "Aceptar"
        Me.BtnAceptarGrpBxAdmin2.UseVisualStyleBackColor = True
        '
        'TxtBx2GrpBxAdmin2
        '
        Me.TxtBx2GrpBxAdmin2.Location = New System.Drawing.Point(6, 71)
        Me.TxtBx2GrpBxAdmin2.Name = "TxtBx2GrpBxAdmin2"
        Me.TxtBx2GrpBxAdmin2.Size = New System.Drawing.Size(124, 20)
        Me.TxtBx2GrpBxAdmin2.TabIndex = 3
        '
        'TxtBx1GrpBxAdmin2
        '
        Me.TxtBx1GrpBxAdmin2.Location = New System.Drawing.Point(6, 32)
        Me.TxtBx1GrpBxAdmin2.Name = "TxtBx1GrpBxAdmin2"
        Me.TxtBx1GrpBxAdmin2.Size = New System.Drawing.Size(124, 20)
        Me.TxtBx1GrpBxAdmin2.TabIndex = 2
        '
        'Lbl2GrpBxAdmin2
        '
        Me.Lbl2GrpBxAdmin2.AutoSize = True
        Me.Lbl2GrpBxAdmin2.Location = New System.Drawing.Point(3, 55)
        Me.Lbl2GrpBxAdmin2.Name = "Lbl2GrpBxAdmin2"
        Me.Lbl2GrpBxAdmin2.Size = New System.Drawing.Size(39, 13)
        Me.Lbl2GrpBxAdmin2.TabIndex = 1
        Me.Lbl2GrpBxAdmin2.Text = "Label2"
        '
        'Lbl1GrpBxAdmin2
        '
        Me.Lbl1GrpBxAdmin2.AutoSize = True
        Me.Lbl1GrpBxAdmin2.Location = New System.Drawing.Point(3, 16)
        Me.Lbl1GrpBxAdmin2.Name = "Lbl1GrpBxAdmin2"
        Me.Lbl1GrpBxAdmin2.Size = New System.Drawing.Size(39, 13)
        Me.Lbl1GrpBxAdmin2.TabIndex = 0
        Me.Lbl1GrpBxAdmin2.Text = "Label1"
        '
        'GrpBxAdmin
        '
        Me.GrpBxAdmin.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpBxAdmin.Controls.Add(Me.BtnEliminarRegistro)
        Me.GrpBxAdmin.Controls.Add(Me.BtnModificarRegistroAdmin)
        Me.GrpBxAdmin.Controls.Add(Me.BtnNuevoRegistro)
        Me.GrpBxAdmin.Location = New System.Drawing.Point(206, 318)
        Me.GrpBxAdmin.Name = "GrpBxAdmin"
        Me.GrpBxAdmin.Size = New System.Drawing.Size(285, 68)
        Me.GrpBxAdmin.TabIndex = 5
        Me.GrpBxAdmin.TabStop = False
        Me.GrpBxAdmin.Visible = False
        '
        'BtnEliminarRegistro
        '
        Me.BtnEliminarRegistro.Enabled = False
        Me.BtnEliminarRegistro.Location = New System.Drawing.Point(200, 18)
        Me.BtnEliminarRegistro.Name = "BtnEliminarRegistro"
        Me.BtnEliminarRegistro.Size = New System.Drawing.Size(78, 39)
        Me.BtnEliminarRegistro.TabIndex = 6
        Me.BtnEliminarRegistro.Text = "Eliminar Registro"
        Me.BtnEliminarRegistro.UseVisualStyleBackColor = True
        '
        'BtnModificarRegistroAdmin
        '
        Me.BtnModificarRegistroAdmin.Enabled = False
        Me.BtnModificarRegistroAdmin.Location = New System.Drawing.Point(105, 18)
        Me.BtnModificarRegistroAdmin.Name = "BtnModificarRegistroAdmin"
        Me.BtnModificarRegistroAdmin.Size = New System.Drawing.Size(89, 39)
        Me.BtnModificarRegistroAdmin.TabIndex = 6
        Me.BtnModificarRegistroAdmin.Text = "Modificar Registro"
        Me.BtnModificarRegistroAdmin.UseVisualStyleBackColor = True
        '
        'BtnNuevoRegistro
        '
        Me.BtnNuevoRegistro.Enabled = False
        Me.BtnNuevoRegistro.Location = New System.Drawing.Point(10, 18)
        Me.BtnNuevoRegistro.Name = "BtnNuevoRegistro"
        Me.BtnNuevoRegistro.Size = New System.Drawing.Size(89, 39)
        Me.BtnNuevoRegistro.TabIndex = 6
        Me.BtnNuevoRegistro.Text = "Nuevo Registro"
        Me.BtnNuevoRegistro.UseVisualStyleBackColor = True
        '
        'CmbBxTablas
        '
        Me.CmbBxTablas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CmbBxTablas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBxTablas.FormattingEnabled = True
        Me.CmbBxTablas.Location = New System.Drawing.Point(8, 324)
        Me.CmbBxTablas.Name = "CmbBxTablas"
        Me.CmbBxTablas.Size = New System.Drawing.Size(171, 21)
        Me.CmbBxTablas.TabIndex = 4
        '
        'DGVAdmin
        '
        Me.DGVAdmin.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGVAdmin.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGVAdmin.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DGVAdmin.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGVAdmin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVAdmin.Location = New System.Drawing.Point(3, 3)
        Me.DGVAdmin.Name = "DGVAdmin"
        Me.DGVAdmin.Size = New System.Drawing.Size(916, 309)
        Me.DGVAdmin.TabIndex = 3
        '
        'LblUsuario
        '
        Me.LblUsuario.AutoSize = True
        Me.LblUsuario.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUsuario.ForeColor = System.Drawing.Color.Red
        Me.LblUsuario.Location = New System.Drawing.Point(4, 4)
        Me.LblUsuario.Name = "LblUsuario"
        Me.LblUsuario.Size = New System.Drawing.Size(57, 17)
        Me.LblUsuario.TabIndex = 3
        Me.LblUsuario.Text = "Label1"
        '
        'BtnDesconectar
        '
        Me.BtnDesconectar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDesconectar.Location = New System.Drawing.Point(839, 4)
        Me.BtnDesconectar.Name = "BtnDesconectar"
        Me.BtnDesconectar.Size = New System.Drawing.Size(90, 39)
        Me.BtnDesconectar.TabIndex = 4
        Me.BtnDesconectar.Text = "Cerrar Sesion"
        Me.BtnDesconectar.UseVisualStyleBackColor = True
        '
        'LblCambiarContraseña
        '
        Me.LblCambiarContraseña.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCambiarContraseña.AutoSize = True
        Me.LblCambiarContraseña.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LblCambiarContraseña.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCambiarContraseña.ForeColor = System.Drawing.Color.Blue
        Me.LblCambiarContraseña.Location = New System.Drawing.Point(713, 6)
        Me.LblCambiarContraseña.Name = "LblCambiarContraseña"
        Me.LblCambiarContraseña.Size = New System.Drawing.Size(120, 13)
        Me.LblCambiarContraseña.TabIndex = 3
        Me.LblCambiarContraseña.Text = "Cambiar Contraseña"
        '
        'LblEsAdmin
        '
        Me.LblEsAdmin.AutoSize = True
        Me.LblEsAdmin.Location = New System.Drawing.Point(60, 6)
        Me.LblEsAdmin.Name = "LblEsAdmin"
        Me.LblEsAdmin.Size = New System.Drawing.Size(39, 13)
        Me.LblEsAdmin.TabIndex = 5
        Me.LblEsAdmin.Text = "Label1"
        Me.LblEsAdmin.Visible = False
        '
        'GrpBxTipoSesion
        '
        Me.GrpBxTipoSesion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpBxTipoSesion.Controls.Add(Me.RBAnalista)
        Me.GrpBxTipoSesion.Controls.Add(Me.RBAdmin)
        Me.GrpBxTipoSesion.Location = New System.Drawing.Point(544, 0)
        Me.GrpBxTipoSesion.Name = "GrpBxTipoSesion"
        Me.GrpBxTipoSesion.Size = New System.Drawing.Size(168, 40)
        Me.GrpBxTipoSesion.TabIndex = 6
        Me.GrpBxTipoSesion.TabStop = False
        Me.GrpBxTipoSesion.Visible = False
        '
        'RBAnalista
        '
        Me.RBAnalista.AutoSize = True
        Me.RBAnalista.Location = New System.Drawing.Point(104, 16)
        Me.RBAnalista.Name = "RBAnalista"
        Me.RBAnalista.Size = New System.Drawing.Size(62, 17)
        Me.RBAnalista.TabIndex = 1
        Me.RBAnalista.TabStop = True
        Me.RBAnalista.Text = "Analista"
        Me.RBAnalista.UseVisualStyleBackColor = True
        '
        'RBAdmin
        '
        Me.RBAdmin.AutoSize = True
        Me.RBAdmin.Location = New System.Drawing.Point(6, 16)
        Me.RBAdmin.Name = "RBAdmin"
        Me.RBAdmin.Size = New System.Drawing.Size(88, 17)
        Me.RBAdmin.TabIndex = 0
        Me.RBAdmin.TabStop = True
        Me.RBAdmin.Text = "Administrador"
        Me.RBAdmin.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(935, 482)
        Me.Controls.Add(Me.GrpBxTipoSesion)
        Me.Controls.Add(Me.LblEsAdmin)
        Me.Controls.Add(Me.LblCambiarContraseña)
        Me.Controls.Add(Me.BtnDesconectar)
        Me.Controls.Add(Me.LblUsuario)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(951, 521)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manejo de Productos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl1.ResumeLayout(False)
        Me.TabPageRegistrarProducto.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DGVProductosSinRevisar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageProductoLimite.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DGVProductosLimite, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageTransito.ResumeLayout(False)
        CType(Me.DGVTransito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageProductosRevisados.ResumeLayout(False)
        CType(Me.DGVProductosRevisados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageAdmin.ResumeLayout(False)
        Me.GrpBxAdmin2.ResumeLayout(False)
        Me.GrpBxAdmin2.PerformLayout()
        CType(Me.Intervalo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpBxAdmin.ResumeLayout(False)
        CType(Me.DGVAdmin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpBxTipoSesion.ResumeLayout(False)
        Me.GrpBxTipoSesion.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPageRegistrarProducto As TabPage
    Friend WithEvents TabPageProductoLimite As TabPage
    Friend WithEvents DGVProductosSinRevisar As DataGridView
    Friend WithEvents DGVProductosLimite As DataGridView
    Friend WithEvents LblUsuario As Label
    Friend WithEvents BtnDesconectar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LblNumeroProducto As Label
    Friend WithEvents TxtBxProductoID As TextBox
    Friend WithEvents CmbBxClientes As ComboBox
    Friend WithEvents LblCliente As Label
    Friend WithEvents LblTipoProducto As Label
    Friend WithEvents BtnModificarRegistro As Button
    Friend WithEvents BtnRegistrarProducto As Button
    Friend WithEvents DTPFechaLimite As DateTimePicker
    Friend WithEvents LblFechaLimite As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents DTPFechaLimite2 As DateTimePicker
    Friend WithEvents LblFechaLimite2 As Label
    Friend WithEvents BtnModificarRegistroLimite As Button
    Friend WithEvents CmbBxProducto2 As ComboBox
    Friend WithEvents LblProducto2 As Label
    Friend WithEvents CmbBxCliente2 As ComboBox
    Friend WithEvents LblCliente2 As Label
    Friend WithEvents LblNumeroProducto2 As Label
    Friend WithEvents TxtBxNumeroProducto2 As TextBox
    Friend WithEvents LblCambiarContraseña As Label
    Friend WithEvents TabPageAdmin As TabPage
    Friend WithEvents DGVAdmin As DataGridView
    Friend WithEvents CmbBxTablas As ComboBox
    Friend WithEvents GrpBxAdmin As GroupBox
    Friend WithEvents BtnEliminarRegistro As Button
    Friend WithEvents BtnModificarRegistroAdmin As Button
    Friend WithEvents BtnNuevoRegistro As Button
    Friend WithEvents GrpBxAdmin2 As GroupBox
    Friend WithEvents TxtBx2GrpBxAdmin2 As TextBox
    Friend WithEvents TxtBx1GrpBxAdmin2 As TextBox
    Friend WithEvents Lbl2GrpBxAdmin2 As Label
    Friend WithEvents Lbl1GrpBxAdmin2 As Label
    Friend WithEvents BtnAceptarGrpBxAdmin2 As Button
    Friend WithEvents TxtBx3GrpBxAdmin2 As TextBox
    Friend WithEvents Lbl3GrpBxAdmin2 As Label
    Friend WithEvents CmbBx1GrpBxAdmin2 As ComboBox
    Friend WithEvents CmbBx2GrpBxAdmin2 As ComboBox
    Friend WithEvents Intervalo As NumericUpDown
    Friend WithEvents LblEsAdmin As Label
    Friend WithEvents GrpBxTipoSesion As GroupBox
    Friend WithEvents RBAnalista As RadioButton
    Friend WithEvents RBAdmin As RadioButton
    Friend WithEvents CmbBxEsAdmin As ComboBox
    Friend WithEvents LblValorAdmin As Label
    Friend WithEvents TabPageProductosRevisados As TabPage
    Friend WithEvents DGVProductosRevisados As DataGridView
    Friend WithEvents CmbBxTipoProducto As ComboBox
    Friend WithEvents TabPageTransito As TabPage
    Friend WithEvents DGVTransito As DataGridView
End Class
