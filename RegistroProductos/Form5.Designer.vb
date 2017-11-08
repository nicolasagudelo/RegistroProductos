<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form5
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form5))
        Me.TxtBxHoraEntrada = New System.Windows.Forms.TextBox()
        Me.LblHoraEntrada = New System.Windows.Forms.Label()
        Me.TxtBxDireccion = New System.Windows.Forms.TextBox()
        Me.LblDireccion = New System.Windows.Forms.Label()
        Me.TxtBxClienteID = New System.Windows.Forms.TextBox()
        Me.TxtBxTipoProductoID = New System.Windows.Forms.TextBox()
        Me.TxtBxIdUsuario = New System.Windows.Forms.TextBox()
        Me.LblIDUsuario = New System.Windows.Forms.Label()
        Me.TxtBxUsuario = New System.Windows.Forms.TextBox()
        Me.LblUsuario = New System.Windows.Forms.Label()
        Me.TxtBxFechaReporte = New System.Windows.Forms.TextBox()
        Me.TxtBxFechaEntrada = New System.Windows.Forms.TextBox()
        Me.LblFechaReporte = New System.Windows.Forms.Label()
        Me.LblFechaEntrada = New System.Windows.Forms.Label()
        Me.RchTxtBxObservaciones = New System.Windows.Forms.RichTextBox()
        Me.LblObservaciones = New System.Windows.Forms.Label()
        Me.TxtBxProducto = New System.Windows.Forms.TextBox()
        Me.LblTipoMercancia = New System.Windows.Forms.Label()
        Me.TxtBxCliente = New System.Windows.Forms.TextBox()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.TxtBxIDProducto = New System.Windows.Forms.TextBox()
        Me.LblIDProducto = New System.Windows.Forms.Label()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.BtnRechazarReporte = New System.Windows.Forms.Button()
        Me.BtnAceptarReporte = New System.Windows.Forms.Button()
        Me.GrpBxTipoPrueba = New System.Windows.Forms.GroupBox()
        Me.RBBasica = New System.Windows.Forms.RadioButton()
        Me.RBEspecifica = New System.Windows.Forms.RadioButton()
        Me.RBCompleta = New System.Windows.Forms.RadioButton()
        Me.TxtBxPeriodoAnalisis = New System.Windows.Forms.TextBox()
        Me.LblPeriodoAnalisis = New System.Windows.Forms.Label()
        Me.TxtBxIDMuestra = New System.Windows.Forms.TextBox()
        Me.LblIdMuestra = New System.Windows.Forms.Label()
        Me.TxtBxOrigen = New System.Windows.Forms.TextBox()
        Me.LblOrigen = New System.Windows.Forms.Label()
        Me.TxtBxLote = New System.Windows.Forms.TextBox()
        Me.LblLote = New System.Windows.Forms.Label()
        Me.TxtBxATN = New System.Windows.Forms.TextBox()
        Me.LblATN = New System.Windows.Forms.Label()
        Me.BtnGenerarPDF = New System.Windows.Forms.Button()
        Me.CBPruebaMicro = New System.Windows.Forms.CheckBox()
        Me.LblPorcentajeBioD = New System.Windows.Forms.Label()
        Me.PorcentajeBioD = New System.Windows.Forms.TextBox()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpBxTipoPrueba.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtBxHoraEntrada
        '
        Me.TxtBxHoraEntrada.Location = New System.Drawing.Point(241, 237)
        Me.TxtBxHoraEntrada.Name = "TxtBxHoraEntrada"
        Me.TxtBxHoraEntrada.ReadOnly = True
        Me.TxtBxHoraEntrada.Size = New System.Drawing.Size(128, 20)
        Me.TxtBxHoraEntrada.TabIndex = 55
        '
        'LblHoraEntrada
        '
        Me.LblHoraEntrada.AutoSize = True
        Me.LblHoraEntrada.Location = New System.Drawing.Point(238, 221)
        Me.LblHoraEntrada.Name = "LblHoraEntrada"
        Me.LblHoraEntrada.Size = New System.Drawing.Size(88, 13)
        Me.LblHoraEntrada.TabIndex = 54
        Me.LblHoraEntrada.Text = "Hora de Entrada:"
        '
        'TxtBxDireccion
        '
        Me.TxtBxDireccion.Location = New System.Drawing.Point(241, 133)
        Me.TxtBxDireccion.Name = "TxtBxDireccion"
        Me.TxtBxDireccion.ReadOnly = True
        Me.TxtBxDireccion.Size = New System.Drawing.Size(128, 20)
        Me.TxtBxDireccion.TabIndex = 53
        '
        'LblDireccion
        '
        Me.LblDireccion.AutoSize = True
        Me.LblDireccion.Location = New System.Drawing.Point(238, 117)
        Me.LblDireccion.Name = "LblDireccion"
        Me.LblDireccion.Size = New System.Drawing.Size(55, 13)
        Me.LblDireccion.TabIndex = 52
        Me.LblDireccion.Text = "Direccion:"
        '
        'TxtBxClienteID
        '
        Me.TxtBxClienteID.Location = New System.Drawing.Point(452, 24)
        Me.TxtBxClienteID.Name = "TxtBxClienteID"
        Me.TxtBxClienteID.Size = New System.Drawing.Size(10, 20)
        Me.TxtBxClienteID.TabIndex = 51
        Me.TxtBxClienteID.Visible = False
        '
        'TxtBxTipoProductoID
        '
        Me.TxtBxTipoProductoID.Location = New System.Drawing.Point(392, 24)
        Me.TxtBxTipoProductoID.Name = "TxtBxTipoProductoID"
        Me.TxtBxTipoProductoID.Size = New System.Drawing.Size(29, 20)
        Me.TxtBxTipoProductoID.TabIndex = 50
        Me.TxtBxTipoProductoID.Visible = False
        '
        'TxtBxIdUsuario
        '
        Me.TxtBxIdUsuario.Location = New System.Drawing.Point(241, 24)
        Me.TxtBxIdUsuario.MaximumSize = New System.Drawing.Size(128, 20)
        Me.TxtBxIdUsuario.MinimumSize = New System.Drawing.Size(128, 20)
        Me.TxtBxIdUsuario.Name = "TxtBxIdUsuario"
        Me.TxtBxIdUsuario.ReadOnly = True
        Me.TxtBxIdUsuario.Size = New System.Drawing.Size(128, 20)
        Me.TxtBxIdUsuario.TabIndex = 49
        '
        'LblIDUsuario
        '
        Me.LblIDUsuario.AutoSize = True
        Me.LblIDUsuario.Location = New System.Drawing.Point(238, 8)
        Me.LblIDUsuario.Name = "LblIDUsuario"
        Me.LblIDUsuario.Size = New System.Drawing.Size(60, 13)
        Me.LblIDUsuario.TabIndex = 48
        Me.LblIDUsuario.Text = "ID Usuario:"
        '
        'TxtBxUsuario
        '
        Me.TxtBxUsuario.Location = New System.Drawing.Point(27, 24)
        Me.TxtBxUsuario.Name = "TxtBxUsuario"
        Me.TxtBxUsuario.ReadOnly = True
        Me.TxtBxUsuario.Size = New System.Drawing.Size(128, 20)
        Me.TxtBxUsuario.TabIndex = 47
        '
        'LblUsuario
        '
        Me.LblUsuario.AutoSize = True
        Me.LblUsuario.Location = New System.Drawing.Point(24, 8)
        Me.LblUsuario.Name = "LblUsuario"
        Me.LblUsuario.Size = New System.Drawing.Size(148, 13)
        Me.LblUsuario.TabIndex = 46
        Me.LblUsuario.Text = "Usuario que realizo el analisis:"
        '
        'TxtBxFechaReporte
        '
        Me.TxtBxFechaReporte.Location = New System.Drawing.Point(241, 286)
        Me.TxtBxFechaReporte.Name = "TxtBxFechaReporte"
        Me.TxtBxFechaReporte.ReadOnly = True
        Me.TxtBxFechaReporte.Size = New System.Drawing.Size(128, 20)
        Me.TxtBxFechaReporte.TabIndex = 45
        '
        'TxtBxFechaEntrada
        '
        Me.TxtBxFechaEntrada.Location = New System.Drawing.Point(241, 183)
        Me.TxtBxFechaEntrada.Name = "TxtBxFechaEntrada"
        Me.TxtBxFechaEntrada.ReadOnly = True
        Me.TxtBxFechaEntrada.Size = New System.Drawing.Size(128, 20)
        Me.TxtBxFechaEntrada.TabIndex = 44
        '
        'LblFechaReporte
        '
        Me.LblFechaReporte.AutoSize = True
        Me.LblFechaReporte.Location = New System.Drawing.Point(238, 270)
        Me.LblFechaReporte.Name = "LblFechaReporte"
        Me.LblFechaReporte.Size = New System.Drawing.Size(96, 13)
        Me.LblFechaReporte.TabIndex = 43
        Me.LblFechaReporte.Text = "Fecha de Reporte:"
        '
        'LblFechaEntrada
        '
        Me.LblFechaEntrada.AutoSize = True
        Me.LblFechaEntrada.Location = New System.Drawing.Point(238, 167)
        Me.LblFechaEntrada.Name = "LblFechaEntrada"
        Me.LblFechaEntrada.Size = New System.Drawing.Size(95, 13)
        Me.LblFechaEntrada.TabIndex = 42
        Me.LblFechaEntrada.Text = "Fecha de Entrada:"
        '
        'RchTxtBxObservaciones
        '
        Me.RchTxtBxObservaciones.Location = New System.Drawing.Point(27, 183)
        Me.RchTxtBxObservaciones.MaxLength = 150
        Me.RchTxtBxObservaciones.Name = "RchTxtBxObservaciones"
        Me.RchTxtBxObservaciones.Size = New System.Drawing.Size(171, 153)
        Me.RchTxtBxObservaciones.TabIndex = 41
        Me.RchTxtBxObservaciones.Text = ""
        '
        'LblObservaciones
        '
        Me.LblObservaciones.AutoSize = True
        Me.LblObservaciones.Location = New System.Drawing.Point(24, 167)
        Me.LblObservaciones.Name = "LblObservaciones"
        Me.LblObservaciones.Size = New System.Drawing.Size(81, 13)
        Me.LblObservaciones.TabIndex = 40
        Me.LblObservaciones.Text = "Observaciones:"
        '
        'TxtBxProducto
        '
        Me.TxtBxProducto.Location = New System.Drawing.Point(27, 133)
        Me.TxtBxProducto.Name = "TxtBxProducto"
        Me.TxtBxProducto.ReadOnly = True
        Me.TxtBxProducto.Size = New System.Drawing.Size(128, 20)
        Me.TxtBxProducto.TabIndex = 37
        '
        'LblTipoMercancia
        '
        Me.LblTipoMercancia.AutoSize = True
        Me.LblTipoMercancia.Location = New System.Drawing.Point(24, 117)
        Me.LblTipoMercancia.Name = "LblTipoMercancia"
        Me.LblTipoMercancia.Size = New System.Drawing.Size(53, 13)
        Me.LblTipoMercancia.TabIndex = 36
        Me.LblTipoMercancia.Text = "Producto:"
        '
        'TxtBxCliente
        '
        Me.TxtBxCliente.Location = New System.Drawing.Point(241, 84)
        Me.TxtBxCliente.Name = "TxtBxCliente"
        Me.TxtBxCliente.ReadOnly = True
        Me.TxtBxCliente.Size = New System.Drawing.Size(128, 20)
        Me.TxtBxCliente.TabIndex = 35
        '
        'LblCliente
        '
        Me.LblCliente.AutoSize = True
        Me.LblCliente.Location = New System.Drawing.Point(238, 55)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(42, 13)
        Me.LblCliente.TabIndex = 34
        Me.LblCliente.Text = "Cliente:"
        '
        'TxtBxIDProducto
        '
        Me.TxtBxIDProducto.Location = New System.Drawing.Point(27, 84)
        Me.TxtBxIDProducto.Name = "TxtBxIDProducto"
        Me.TxtBxIDProducto.ReadOnly = True
        Me.TxtBxIDProducto.Size = New System.Drawing.Size(128, 20)
        Me.TxtBxIDProducto.TabIndex = 33
        '
        'LblIDProducto
        '
        Me.LblIDProducto.AutoSize = True
        Me.LblIDProducto.Location = New System.Drawing.Point(24, 55)
        Me.LblIDProducto.Name = "LblIDProducto"
        Me.LblIDProducto.Size = New System.Drawing.Size(85, 26)
        Me.LblIDProducto.TabIndex = 32
        Me.LblIDProducto.Text = "Identificador del " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Producto:"
        '
        'DGV
        '
        Me.DGV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DGV.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(448, 16)
        Me.DGV.Name = "DGV"
        Me.DGV.Size = New System.Drawing.Size(440, 592)
        Me.DGV.TabIndex = 56
        '
        'BtnRechazarReporte
        '
        Me.BtnRechazarReporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRechazarReporte.Location = New System.Drawing.Point(813, 655)
        Me.BtnRechazarReporte.Name = "BtnRechazarReporte"
        Me.BtnRechazarReporte.Size = New System.Drawing.Size(75, 40)
        Me.BtnRechazarReporte.TabIndex = 58
        Me.BtnRechazarReporte.Text = "Rechazar Reporte"
        Me.BtnRechazarReporte.UseVisualStyleBackColor = True
        '
        'BtnAceptarReporte
        '
        Me.BtnAceptarReporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAceptarReporte.Location = New System.Drawing.Point(732, 655)
        Me.BtnAceptarReporte.Name = "BtnAceptarReporte"
        Me.BtnAceptarReporte.Size = New System.Drawing.Size(75, 40)
        Me.BtnAceptarReporte.TabIndex = 57
        Me.BtnAceptarReporte.Text = "Aceptar Reporte"
        Me.BtnAceptarReporte.UseVisualStyleBackColor = True
        '
        'GrpBxTipoPrueba
        '
        Me.GrpBxTipoPrueba.Controls.Add(Me.RBBasica)
        Me.GrpBxTipoPrueba.Controls.Add(Me.RBEspecifica)
        Me.GrpBxTipoPrueba.Controls.Add(Me.RBCompleta)
        Me.GrpBxTipoPrueba.Location = New System.Drawing.Point(24, 352)
        Me.GrpBxTipoPrueba.Name = "GrpBxTipoPrueba"
        Me.GrpBxTipoPrueba.Size = New System.Drawing.Size(120, 100)
        Me.GrpBxTipoPrueba.TabIndex = 59
        Me.GrpBxTipoPrueba.TabStop = False
        Me.GrpBxTipoPrueba.Text = "Tipo de Prueba"
        '
        'RBBasica
        '
        Me.RBBasica.AutoSize = True
        Me.RBBasica.Location = New System.Drawing.Point(8, 48)
        Me.RBBasica.Name = "RBBasica"
        Me.RBBasica.Size = New System.Drawing.Size(57, 17)
        Me.RBBasica.TabIndex = 60
        Me.RBBasica.TabStop = True
        Me.RBBasica.Text = "Basica"
        Me.RBBasica.UseVisualStyleBackColor = True
        '
        'RBEspecifica
        '
        Me.RBEspecifica.AutoSize = True
        Me.RBEspecifica.Location = New System.Drawing.Point(8, 72)
        Me.RBEspecifica.Name = "RBEspecifica"
        Me.RBEspecifica.Size = New System.Drawing.Size(74, 17)
        Me.RBEspecifica.TabIndex = 1
        Me.RBEspecifica.TabStop = True
        Me.RBEspecifica.Text = "Especifica"
        Me.RBEspecifica.UseVisualStyleBackColor = True
        '
        'RBCompleta
        '
        Me.RBCompleta.AutoSize = True
        Me.RBCompleta.Location = New System.Drawing.Point(8, 24)
        Me.RBCompleta.Name = "RBCompleta"
        Me.RBCompleta.Size = New System.Drawing.Size(69, 17)
        Me.RBCompleta.TabIndex = 0
        Me.RBCompleta.Text = "Completa"
        Me.RBCompleta.UseVisualStyleBackColor = True
        '
        'TxtBxPeriodoAnalisis
        '
        Me.TxtBxPeriodoAnalisis.Location = New System.Drawing.Point(241, 335)
        Me.TxtBxPeriodoAnalisis.Name = "TxtBxPeriodoAnalisis"
        Me.TxtBxPeriodoAnalisis.ReadOnly = True
        Me.TxtBxPeriodoAnalisis.Size = New System.Drawing.Size(128, 20)
        Me.TxtBxPeriodoAnalisis.TabIndex = 61
        '
        'LblPeriodoAnalisis
        '
        Me.LblPeriodoAnalisis.AutoSize = True
        Me.LblPeriodoAnalisis.Location = New System.Drawing.Point(238, 319)
        Me.LblPeriodoAnalisis.Name = "LblPeriodoAnalisis"
        Me.LblPeriodoAnalisis.Size = New System.Drawing.Size(96, 13)
        Me.LblPeriodoAnalisis.TabIndex = 60
        Me.LblPeriodoAnalisis.Text = "Periodo de Analisis"
        '
        'TxtBxIDMuestra
        '
        Me.TxtBxIDMuestra.Location = New System.Drawing.Point(241, 379)
        Me.TxtBxIDMuestra.Name = "TxtBxIDMuestra"
        Me.TxtBxIDMuestra.ReadOnly = True
        Me.TxtBxIDMuestra.Size = New System.Drawing.Size(128, 20)
        Me.TxtBxIDMuestra.TabIndex = 63
        '
        'LblIdMuestra
        '
        Me.LblIdMuestra.AutoSize = True
        Me.LblIdMuestra.Location = New System.Drawing.Point(238, 363)
        Me.LblIdMuestra.Name = "LblIdMuestra"
        Me.LblIdMuestra.Size = New System.Drawing.Size(62, 13)
        Me.LblIdMuestra.TabIndex = 62
        Me.LblIdMuestra.Text = "ID Muestra:"
        '
        'TxtBxOrigen
        '
        Me.TxtBxOrigen.Location = New System.Drawing.Point(27, 482)
        Me.TxtBxOrigen.Name = "TxtBxOrigen"
        Me.TxtBxOrigen.ReadOnly = True
        Me.TxtBxOrigen.Size = New System.Drawing.Size(128, 20)
        Me.TxtBxOrigen.TabIndex = 65
        '
        'LblOrigen
        '
        Me.LblOrigen.AutoSize = True
        Me.LblOrigen.Location = New System.Drawing.Point(24, 466)
        Me.LblOrigen.Name = "LblOrigen"
        Me.LblOrigen.Size = New System.Drawing.Size(83, 13)
        Me.LblOrigen.TabIndex = 64
        Me.LblOrigen.Text = "Origen/Tanque:"
        '
        'TxtBxLote
        '
        Me.TxtBxLote.Location = New System.Drawing.Point(27, 529)
        Me.TxtBxLote.Name = "TxtBxLote"
        Me.TxtBxLote.ReadOnly = True
        Me.TxtBxLote.Size = New System.Drawing.Size(128, 20)
        Me.TxtBxLote.TabIndex = 67
        '
        'LblLote
        '
        Me.LblLote.AutoSize = True
        Me.LblLote.Location = New System.Drawing.Point(24, 513)
        Me.LblLote.Name = "LblLote"
        Me.LblLote.Size = New System.Drawing.Size(79, 13)
        Me.LblLote.TabIndex = 66
        Me.LblLote.Text = "Cochada/Lote:"
        '
        'TxtBxATN
        '
        Me.TxtBxATN.Location = New System.Drawing.Point(241, 432)
        Me.TxtBxATN.Name = "TxtBxATN"
        Me.TxtBxATN.Size = New System.Drawing.Size(128, 20)
        Me.TxtBxATN.TabIndex = 69
        '
        'LblATN
        '
        Me.LblATN.AutoSize = True
        Me.LblATN.Location = New System.Drawing.Point(238, 416)
        Me.LblATN.Name = "LblATN"
        Me.LblATN.Size = New System.Drawing.Size(32, 13)
        Me.LblATN.TabIndex = 68
        Me.LblATN.Text = "ATN:"
        '
        'BtnGenerarPDF
        '
        Me.BtnGenerarPDF.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGenerarPDF.Location = New System.Drawing.Point(797, 614)
        Me.BtnGenerarPDF.Name = "BtnGenerarPDF"
        Me.BtnGenerarPDF.Size = New System.Drawing.Size(91, 81)
        Me.BtnGenerarPDF.TabIndex = 70
        Me.BtnGenerarPDF.Text = "Generar PDF"
        Me.BtnGenerarPDF.UseVisualStyleBackColor = True
        Me.BtnGenerarPDF.Visible = False
        '
        'CBPruebaMicro
        '
        Me.CBPruebaMicro.AutoSize = True
        Me.CBPruebaMicro.Location = New System.Drawing.Point(241, 479)
        Me.CBPruebaMicro.Name = "CBPruebaMicro"
        Me.CBPruebaMicro.Size = New System.Drawing.Size(143, 17)
        Me.CBPruebaMicro.TabIndex = 71
        Me.CBPruebaMicro.Text = "¿Prueba Microbiologica?"
        Me.CBPruebaMicro.UseVisualStyleBackColor = True
        Me.CBPruebaMicro.Visible = False
        '
        'LblPorcentajeBioD
        '
        Me.LblPorcentajeBioD.AutoSize = True
        Me.LblPorcentajeBioD.Location = New System.Drawing.Point(24, 562)
        Me.LblPorcentajeBioD.Name = "LblPorcentajeBioD"
        Me.LblPorcentajeBioD.Size = New System.Drawing.Size(108, 13)
        Me.LblPorcentajeBioD.TabIndex = 73
        Me.LblPorcentajeBioD.Text = "Porcentaje BioDiesel:"
        '
        'PorcentajeBioD
        '
        Me.PorcentajeBioD.Location = New System.Drawing.Point(27, 578)
        Me.PorcentajeBioD.Name = "PorcentajeBioD"
        Me.PorcentajeBioD.ReadOnly = True
        Me.PorcentajeBioD.Size = New System.Drawing.Size(128, 20)
        Me.PorcentajeBioD.TabIndex = 74
        '
        'Form5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(893, 707)
        Me.Controls.Add(Me.PorcentajeBioD)
        Me.Controls.Add(Me.LblPorcentajeBioD)
        Me.Controls.Add(Me.CBPruebaMicro)
        Me.Controls.Add(Me.TxtBxATN)
        Me.Controls.Add(Me.LblATN)
        Me.Controls.Add(Me.TxtBxLote)
        Me.Controls.Add(Me.LblLote)
        Me.Controls.Add(Me.TxtBxOrigen)
        Me.Controls.Add(Me.LblOrigen)
        Me.Controls.Add(Me.TxtBxIDMuestra)
        Me.Controls.Add(Me.LblIdMuestra)
        Me.Controls.Add(Me.TxtBxPeriodoAnalisis)
        Me.Controls.Add(Me.LblPeriodoAnalisis)
        Me.Controls.Add(Me.GrpBxTipoPrueba)
        Me.Controls.Add(Me.BtnRechazarReporte)
        Me.Controls.Add(Me.BtnAceptarReporte)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.TxtBxHoraEntrada)
        Me.Controls.Add(Me.LblHoraEntrada)
        Me.Controls.Add(Me.TxtBxDireccion)
        Me.Controls.Add(Me.LblDireccion)
        Me.Controls.Add(Me.TxtBxClienteID)
        Me.Controls.Add(Me.TxtBxTipoProductoID)
        Me.Controls.Add(Me.TxtBxIdUsuario)
        Me.Controls.Add(Me.LblIDUsuario)
        Me.Controls.Add(Me.TxtBxUsuario)
        Me.Controls.Add(Me.LblUsuario)
        Me.Controls.Add(Me.TxtBxFechaReporte)
        Me.Controls.Add(Me.TxtBxFechaEntrada)
        Me.Controls.Add(Me.LblFechaReporte)
        Me.Controls.Add(Me.LblFechaEntrada)
        Me.Controls.Add(Me.RchTxtBxObservaciones)
        Me.Controls.Add(Me.LblObservaciones)
        Me.Controls.Add(Me.TxtBxProducto)
        Me.Controls.Add(Me.LblTipoMercancia)
        Me.Controls.Add(Me.TxtBxCliente)
        Me.Controls.Add(Me.LblCliente)
        Me.Controls.Add(Me.TxtBxIDProducto)
        Me.Controls.Add(Me.LblIDProducto)
        Me.Controls.Add(Me.BtnGenerarPDF)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form5"
        Me.Text = "Form5"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpBxTipoPrueba.ResumeLayout(False)
        Me.GrpBxTipoPrueba.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtBxHoraEntrada As TextBox
    Friend WithEvents LblHoraEntrada As Label
    Friend WithEvents TxtBxDireccion As TextBox
    Friend WithEvents LblDireccion As Label
    Friend WithEvents TxtBxClienteID As TextBox
    Friend WithEvents TxtBxTipoProductoID As TextBox
    Friend WithEvents TxtBxIdUsuario As TextBox
    Friend WithEvents LblIDUsuario As Label
    Friend WithEvents TxtBxUsuario As TextBox
    Friend WithEvents LblUsuario As Label
    Friend WithEvents TxtBxFechaReporte As TextBox
    Friend WithEvents TxtBxFechaEntrada As TextBox
    Friend WithEvents LblFechaReporte As Label
    Friend WithEvents LblFechaEntrada As Label
    Friend WithEvents RchTxtBxObservaciones As RichTextBox
    Friend WithEvents LblObservaciones As Label
    Friend WithEvents TxtBxProducto As TextBox
    Friend WithEvents LblTipoMercancia As Label
    Friend WithEvents TxtBxCliente As TextBox
    Friend WithEvents LblCliente As Label
    Friend WithEvents TxtBxIDProducto As TextBox
    Friend WithEvents LblIDProducto As Label
    Friend WithEvents DGV As DataGridView
    Friend WithEvents BtnRechazarReporte As Button
    Friend WithEvents BtnAceptarReporte As Button
    Friend WithEvents GrpBxTipoPrueba As GroupBox
    Friend WithEvents RBEspecifica As RadioButton
    Friend WithEvents RBCompleta As RadioButton
    Friend WithEvents RBBasica As RadioButton
    Friend WithEvents TxtBxPeriodoAnalisis As TextBox
    Friend WithEvents LblPeriodoAnalisis As Label
    Friend WithEvents TxtBxIDMuestra As TextBox
    Friend WithEvents LblIdMuestra As Label
    Friend WithEvents TxtBxOrigen As TextBox
    Friend WithEvents LblOrigen As Label
    Friend WithEvents TxtBxLote As TextBox
    Friend WithEvents LblLote As Label
    Friend WithEvents TxtBxATN As TextBox
    Friend WithEvents LblATN As Label
    Friend WithEvents BtnGenerarPDF As Button
    Friend WithEvents CBPruebaMicro As CheckBox
    Friend WithEvents LblPorcentajeBioD As Label
    Friend WithEvents PorcentajeBioD As TextBox
End Class
