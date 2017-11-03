<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form6
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.CmbBxCategorias = New System.Windows.Forms.ComboBox()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.RBQuitarTodo = New System.Windows.Forms.RadioButton()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.RBSeleccionarTodo = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LblCategorias = New System.Windows.Forms.Label()
        Me.LblPorcentajeBioD = New System.Windows.Forms.Label()
        Me.PorcentajeBioD = New System.Windows.Forms.NumericUpDown()
        Me.TxtBxLote = New System.Windows.Forms.TextBox()
        Me.LblLote = New System.Windows.Forms.Label()
        Me.TxtBxOrigen = New System.Windows.Forms.TextBox()
        Me.LblOrigen = New System.Windows.Forms.Label()
        Me.TxtBxIDMuestra = New System.Windows.Forms.TextBox()
        Me.LblIdMuestra = New System.Windows.Forms.Label()
        Me.TxtBxFechaRegistro = New System.Windows.Forms.TextBox()
        Me.LblFechaEntrada = New System.Windows.Forms.Label()
        Me.TxtBxDireccion = New System.Windows.Forms.TextBox()
        Me.LblDireccion = New System.Windows.Forms.Label()
        Me.LblContadorCaracteres = New System.Windows.Forms.Label()
        Me.RchTxtBxObservaciones = New System.Windows.Forms.RichTextBox()
        Me.LblObservacionesCliente = New System.Windows.Forms.Label()
        Me.CmbBxCliente = New System.Windows.Forms.ComboBox()
        Me.CmbBxProducto = New System.Windows.Forms.ComboBox()
        Me.LblTipoMercancia = New System.Windows.Forms.Label()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.BtnGenerarReporte = New System.Windows.Forms.Button()
        Me.LblFechaFin = New System.Windows.Forms.Label()
        Me.FechaFin = New System.Windows.Forms.DateTimePicker()
        Me.LblFechaInicio = New System.Windows.Forms.Label()
        Me.FechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.DGVHistorial = New System.Windows.Forms.DataGridView()
        Me.LblCambiarContraseña = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PorcentajeBioD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.DGVHistorial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(1, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1041, 457)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.LblCambiarContraseña)
        Me.TabPage1.Controls.Add(Me.ProgressBar1)
        Me.TabPage1.Controls.Add(Me.CmbBxCategorias)
        Me.TabPage1.Controls.Add(Me.BtnCancelar)
        Me.TabPage1.Controls.Add(Me.RBQuitarTodo)
        Me.TabPage1.Controls.Add(Me.BtnAceptar)
        Me.TabPage1.Controls.Add(Me.RBSeleccionarTodo)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.LblCategorias)
        Me.TabPage1.Controls.Add(Me.LblPorcentajeBioD)
        Me.TabPage1.Controls.Add(Me.PorcentajeBioD)
        Me.TabPage1.Controls.Add(Me.TxtBxLote)
        Me.TabPage1.Controls.Add(Me.LblLote)
        Me.TabPage1.Controls.Add(Me.TxtBxOrigen)
        Me.TabPage1.Controls.Add(Me.LblOrigen)
        Me.TabPage1.Controls.Add(Me.TxtBxIDMuestra)
        Me.TabPage1.Controls.Add(Me.LblIdMuestra)
        Me.TabPage1.Controls.Add(Me.TxtBxFechaRegistro)
        Me.TabPage1.Controls.Add(Me.LblFechaEntrada)
        Me.TabPage1.Controls.Add(Me.TxtBxDireccion)
        Me.TabPage1.Controls.Add(Me.LblDireccion)
        Me.TabPage1.Controls.Add(Me.LblContadorCaracteres)
        Me.TabPage1.Controls.Add(Me.RchTxtBxObservaciones)
        Me.TabPage1.Controls.Add(Me.LblObservacionesCliente)
        Me.TabPage1.Controls.Add(Me.CmbBxCliente)
        Me.TabPage1.Controls.Add(Me.CmbBxProducto)
        Me.TabPage1.Controls.Add(Me.LblTipoMercancia)
        Me.TabPage1.Controls.Add(Me.LblCliente)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1033, 431)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Registrar Muestra"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(538, 397)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(327, 23)
        Me.ProgressBar1.TabIndex = 83
        '
        'CmbBxCategorias
        '
        Me.CmbBxCategorias.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbBxCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBxCategorias.FormattingEnabled = True
        Me.CmbBxCategorias.Location = New System.Drawing.Point(538, 30)
        Me.CmbBxCategorias.Name = "CmbBxCategorias"
        Me.CmbBxCategorias.Size = New System.Drawing.Size(489, 21)
        Me.CmbBxCategorias.TabIndex = 7
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Location = New System.Drawing.Point(952, 363)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(75, 57)
        Me.BtnCancelar.TabIndex = 12
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'RBQuitarTodo
        '
        Me.RBQuitarTodo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RBQuitarTodo.AutoSize = True
        Me.RBQuitarTodo.Location = New System.Drawing.Point(653, 54)
        Me.RBQuitarTodo.Name = "RBQuitarTodo"
        Me.RBQuitarTodo.Size = New System.Drawing.Size(77, 17)
        Me.RBQuitarTodo.TabIndex = 9
        Me.RBQuitarTodo.Text = "Quitar todo"
        Me.RBQuitarTodo.UseVisualStyleBackColor = True
        Me.RBQuitarTodo.Visible = False
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAceptar.Location = New System.Drawing.Point(871, 363)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(75, 57)
        Me.BtnAceptar.TabIndex = 11
        Me.BtnAceptar.Text = "Registrar Producto"
        Me.BtnAceptar.UseVisualStyleBackColor = True
        '
        'RBSeleccionarTodo
        '
        Me.RBSeleccionarTodo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RBSeleccionarTodo.AutoSize = True
        Me.RBSeleccionarTodo.Checked = True
        Me.RBSeleccionarTodo.Location = New System.Drawing.Point(538, 54)
        Me.RBSeleccionarTodo.Name = "RBSeleccionarTodo"
        Me.RBSeleccionarTodo.Size = New System.Drawing.Size(109, 17)
        Me.RBSeleccionarTodo.TabIndex = 8
        Me.RBSeleccionarTodo.TabStop = True
        Me.RBSeleccionarTodo.Text = "Seleccionar Todo"
        Me.RBSeleccionarTodo.UseVisualStyleBackColor = True
        Me.RBSeleccionarTodo.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Location = New System.Drawing.Point(538, 72)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(489, 285)
        Me.Panel1.TabIndex = 10
        '
        'LblCategorias
        '
        Me.LblCategorias.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCategorias.AutoSize = True
        Me.LblCategorias.Location = New System.Drawing.Point(535, 14)
        Me.LblCategorias.Name = "LblCategorias"
        Me.LblCategorias.Size = New System.Drawing.Size(60, 13)
        Me.LblCategorias.TabIndex = 78
        Me.LblCategorias.Text = "Categorias:"
        '
        'LblPorcentajeBioD
        '
        Me.LblPorcentajeBioD.AutoSize = True
        Me.LblPorcentajeBioD.Location = New System.Drawing.Point(246, 133)
        Me.LblPorcentajeBioD.Name = "LblPorcentajeBioD"
        Me.LblPorcentajeBioD.Size = New System.Drawing.Size(108, 13)
        Me.LblPorcentajeBioD.TabIndex = 77
        Me.LblPorcentajeBioD.Text = "Porcentaje BioDiesel:"
        '
        'PorcentajeBioD
        '
        Me.PorcentajeBioD.Location = New System.Drawing.Point(249, 149)
        Me.PorcentajeBioD.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.PorcentajeBioD.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.PorcentajeBioD.Name = "PorcentajeBioD"
        Me.PorcentajeBioD.Size = New System.Drawing.Size(218, 20)
        Me.PorcentajeBioD.TabIndex = 5
        Me.PorcentajeBioD.Value = New Decimal(New Integer() {1, 0, 0, 0})
        Me.PorcentajeBioD.Visible = False
        '
        'TxtBxLote
        '
        Me.TxtBxLote.Location = New System.Drawing.Point(10, 149)
        Me.TxtBxLote.Name = "TxtBxLote"
        Me.TxtBxLote.Size = New System.Drawing.Size(214, 20)
        Me.TxtBxLote.TabIndex = 4
        '
        'LblLote
        '
        Me.LblLote.AutoSize = True
        Me.LblLote.Location = New System.Drawing.Point(7, 133)
        Me.LblLote.Name = "LblLote"
        Me.LblLote.Size = New System.Drawing.Size(79, 13)
        Me.LblLote.TabIndex = 74
        Me.LblLote.Text = "Cochada/Lote:"
        '
        'TxtBxOrigen
        '
        Me.TxtBxOrigen.Location = New System.Drawing.Point(249, 110)
        Me.TxtBxOrigen.Name = "TxtBxOrigen"
        Me.TxtBxOrigen.Size = New System.Drawing.Size(218, 20)
        Me.TxtBxOrigen.TabIndex = 3
        '
        'LblOrigen
        '
        Me.LblOrigen.AutoSize = True
        Me.LblOrigen.Location = New System.Drawing.Point(246, 94)
        Me.LblOrigen.Name = "LblOrigen"
        Me.LblOrigen.Size = New System.Drawing.Size(83, 13)
        Me.LblOrigen.TabIndex = 72
        Me.LblOrigen.Text = "Origen/Tanque:"
        '
        'TxtBxIDMuestra
        '
        Me.TxtBxIDMuestra.Location = New System.Drawing.Point(10, 110)
        Me.TxtBxIDMuestra.Name = "TxtBxIDMuestra"
        Me.TxtBxIDMuestra.Size = New System.Drawing.Size(214, 20)
        Me.TxtBxIDMuestra.TabIndex = 2
        '
        'LblIdMuestra
        '
        Me.LblIdMuestra.AutoSize = True
        Me.LblIdMuestra.Location = New System.Drawing.Point(7, 94)
        Me.LblIdMuestra.Name = "LblIdMuestra"
        Me.LblIdMuestra.Size = New System.Drawing.Size(62, 13)
        Me.LblIdMuestra.TabIndex = 70
        Me.LblIdMuestra.Text = "ID Muestra:"
        '
        'TxtBxFechaRegistro
        '
        Me.TxtBxFechaRegistro.Location = New System.Drawing.Point(249, 70)
        Me.TxtBxFechaRegistro.Name = "TxtBxFechaRegistro"
        Me.TxtBxFechaRegistro.ReadOnly = True
        Me.TxtBxFechaRegistro.Size = New System.Drawing.Size(218, 20)
        Me.TxtBxFechaRegistro.TabIndex = 47
        '
        'LblFechaEntrada
        '
        Me.LblFechaEntrada.AutoSize = True
        Me.LblFechaEntrada.Location = New System.Drawing.Point(246, 53)
        Me.LblFechaEntrada.Name = "LblFechaEntrada"
        Me.LblFechaEntrada.Size = New System.Drawing.Size(97, 13)
        Me.LblFechaEntrada.TabIndex = 46
        Me.LblFechaEntrada.Text = "Fecha de Registro:"
        '
        'TxtBxDireccion
        '
        Me.TxtBxDireccion.Location = New System.Drawing.Point(249, 30)
        Me.TxtBxDireccion.Name = "TxtBxDireccion"
        Me.TxtBxDireccion.ReadOnly = True
        Me.TxtBxDireccion.Size = New System.Drawing.Size(218, 20)
        Me.TxtBxDireccion.TabIndex = 45
        '
        'LblDireccion
        '
        Me.LblDireccion.AutoSize = True
        Me.LblDireccion.Location = New System.Drawing.Point(246, 14)
        Me.LblDireccion.Name = "LblDireccion"
        Me.LblDireccion.Size = New System.Drawing.Size(55, 13)
        Me.LblDireccion.TabIndex = 44
        Me.LblDireccion.Text = "Direccion:"
        '
        'LblContadorCaracteres
        '
        Me.LblContadorCaracteres.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblContadorCaracteres.AutoSize = True
        Me.LblContadorCaracteres.Location = New System.Drawing.Point(432, 360)
        Me.LblContadorCaracteres.Name = "LblContadorCaracteres"
        Me.LblContadorCaracteres.Size = New System.Drawing.Size(36, 13)
        Me.LblContadorCaracteres.TabIndex = 43
        Me.LblContadorCaracteres.Text = "0/500"
        '
        'RchTxtBxObservaciones
        '
        Me.RchTxtBxObservaciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RchTxtBxObservaciones.Location = New System.Drawing.Point(11, 188)
        Me.RchTxtBxObservaciones.MaxLength = 500
        Me.RchTxtBxObservaciones.Name = "RchTxtBxObservaciones"
        Me.RchTxtBxObservaciones.Size = New System.Drawing.Size(457, 169)
        Me.RchTxtBxObservaciones.TabIndex = 6
        Me.RchTxtBxObservaciones.Text = ""
        '
        'LblObservacionesCliente
        '
        Me.LblObservacionesCliente.AutoSize = True
        Me.LblObservacionesCliente.Location = New System.Drawing.Point(8, 172)
        Me.LblObservacionesCliente.Name = "LblObservacionesCliente"
        Me.LblObservacionesCliente.Size = New System.Drawing.Size(78, 13)
        Me.LblObservacionesCliente.TabIndex = 41
        Me.LblObservacionesCliente.Text = "Observaciones"
        '
        'CmbBxCliente
        '
        Me.CmbBxCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBxCliente.Enabled = False
        Me.CmbBxCliente.FormattingEnabled = True
        Me.CmbBxCliente.Location = New System.Drawing.Point(10, 30)
        Me.CmbBxCliente.Name = "CmbBxCliente"
        Me.CmbBxCliente.Size = New System.Drawing.Size(214, 21)
        Me.CmbBxCliente.TabIndex = 40
        '
        'CmbBxProducto
        '
        Me.CmbBxProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBxProducto.FormattingEnabled = True
        Me.CmbBxProducto.Location = New System.Drawing.Point(10, 70)
        Me.CmbBxProducto.Name = "CmbBxProducto"
        Me.CmbBxProducto.Size = New System.Drawing.Size(214, 21)
        Me.CmbBxProducto.TabIndex = 1
        '
        'LblTipoMercancia
        '
        Me.LblTipoMercancia.AutoSize = True
        Me.LblTipoMercancia.Location = New System.Drawing.Point(7, 54)
        Me.LblTipoMercancia.Name = "LblTipoMercancia"
        Me.LblTipoMercancia.Size = New System.Drawing.Size(53, 13)
        Me.LblTipoMercancia.TabIndex = 38
        Me.LblTipoMercancia.Text = "Producto:"
        '
        'LblCliente
        '
        Me.LblCliente.AutoSize = True
        Me.LblCliente.Location = New System.Drawing.Point(7, 14)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(42, 13)
        Me.LblCliente.TabIndex = 36
        Me.LblCliente.Text = "Cliente:"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.BtnGenerarReporte)
        Me.TabPage2.Controls.Add(Me.LblFechaFin)
        Me.TabPage2.Controls.Add(Me.FechaFin)
        Me.TabPage2.Controls.Add(Me.LblFechaInicio)
        Me.TabPage2.Controls.Add(Me.FechaInicio)
        Me.TabPage2.Controls.Add(Me.DGVHistorial)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1033, 431)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Historial"
        '
        'BtnGenerarReporte
        '
        Me.BtnGenerarReporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnGenerarReporte.Location = New System.Drawing.Point(349, 15)
        Me.BtnGenerarReporte.Name = "BtnGenerarReporte"
        Me.BtnGenerarReporte.Size = New System.Drawing.Size(78, 39)
        Me.BtnGenerarReporte.TabIndex = 26
        Me.BtnGenerarReporte.Text = "Revisar Historial"
        Me.BtnGenerarReporte.UseVisualStyleBackColor = True
        '
        'LblFechaFin
        '
        Me.LblFechaFin.AutoSize = True
        Me.LblFechaFin.Location = New System.Drawing.Point(172, 15)
        Me.LblFechaFin.Name = "LblFechaFin"
        Me.LblFechaFin.Size = New System.Drawing.Size(57, 13)
        Me.LblFechaFin.TabIndex = 25
        Me.LblFechaFin.Text = "Fecha Fin:"
        '
        'FechaFin
        '
        Me.FechaFin.Location = New System.Drawing.Point(175, 31)
        Me.FechaFin.Name = "FechaFin"
        Me.FechaFin.Size = New System.Drawing.Size(146, 20)
        Me.FechaFin.TabIndex = 24
        Me.FechaFin.Value = New Date(2017, 9, 14, 10, 3, 34, 0)
        '
        'LblFechaInicio
        '
        Me.LblFechaInicio.AutoSize = True
        Me.LblFechaInicio.Location = New System.Drawing.Point(7, 15)
        Me.LblFechaInicio.Name = "LblFechaInicio"
        Me.LblFechaInicio.Size = New System.Drawing.Size(68, 13)
        Me.LblFechaInicio.TabIndex = 23
        Me.LblFechaInicio.Text = "Fecha Inicio:"
        '
        'FechaInicio
        '
        Me.FechaInicio.Location = New System.Drawing.Point(10, 31)
        Me.FechaInicio.MinDate = New Date(2017, 1, 1, 0, 0, 0, 0)
        Me.FechaInicio.Name = "FechaInicio"
        Me.FechaInicio.Size = New System.Drawing.Size(146, 20)
        Me.FechaInicio.TabIndex = 22
        Me.FechaInicio.Value = New Date(2017, 9, 14, 10, 3, 34, 0)
        '
        'DGVHistorial
        '
        Me.DGVHistorial.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGVHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGVHistorial.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DGVHistorial.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGVHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVHistorial.Location = New System.Drawing.Point(3, 68)
        Me.DGVHistorial.Name = "DGVHistorial"
        Me.DGVHistorial.Size = New System.Drawing.Size(1024, 360)
        Me.DGVHistorial.TabIndex = 0
        '
        'LblCambiarContraseña
        '
        Me.LblCambiarContraseña.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCambiarContraseña.AutoSize = True
        Me.LblCambiarContraseña.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LblCambiarContraseña.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCambiarContraseña.ForeColor = System.Drawing.Color.Blue
        Me.LblCambiarContraseña.Location = New System.Drawing.Point(8, 407)
        Me.LblCambiarContraseña.Name = "LblCambiarContraseña"
        Me.LblCambiarContraseña.Size = New System.Drawing.Size(120, 13)
        Me.LblCambiarContraseña.TabIndex = 84
        Me.LblCambiarContraseña.Text = "Cambiar Contraseña"
        '
        'Form6
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1054, 458)
        Me.Controls.Add(Me.TabControl1)
        Me.MinimumSize = New System.Drawing.Size(1070, 497)
        Me.Name = "Form6"
        Me.Text = "Form6"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.PorcentajeBioD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.DGVHistorial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents LblCliente As Label
    Friend WithEvents CmbBxCliente As ComboBox
    Friend WithEvents CmbBxProducto As ComboBox
    Friend WithEvents LblTipoMercancia As Label
    Friend WithEvents LblContadorCaracteres As Label
    Friend WithEvents RchTxtBxObservaciones As RichTextBox
    Friend WithEvents LblObservacionesCliente As Label
    Friend WithEvents TxtBxDireccion As TextBox
    Friend WithEvents LblDireccion As Label
    Friend WithEvents TxtBxFechaRegistro As TextBox
    Friend WithEvents LblFechaEntrada As Label
    Friend WithEvents TxtBxIDMuestra As TextBox
    Friend WithEvents LblIdMuestra As Label
    Friend WithEvents TxtBxLote As TextBox
    Friend WithEvents LblLote As Label
    Friend WithEvents TxtBxOrigen As TextBox
    Friend WithEvents LblOrigen As Label
    Friend WithEvents LblPorcentajeBioD As Label
    Friend WithEvents PorcentajeBioD As NumericUpDown
    Friend WithEvents LblCategorias As Label
    Friend WithEvents BtnAceptar As Button
    Friend WithEvents BtnCancelar As Button
    Friend WithEvents RBQuitarTodo As RadioButton
    Friend WithEvents RBSeleccionarTodo As RadioButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents CmbBxCategorias As ComboBox
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents DGVHistorial As DataGridView
    Friend WithEvents BtnGenerarReporte As Button
    Friend WithEvents LblFechaFin As Label
    Friend WithEvents FechaFin As DateTimePicker
    Friend WithEvents LblFechaInicio As Label
    Friend WithEvents FechaInicio As DateTimePicker
    Friend WithEvents LblCambiarContraseña As Label
End Class
