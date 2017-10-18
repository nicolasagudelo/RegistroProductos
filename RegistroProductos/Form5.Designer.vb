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
        Me.TxtBxFechaRegistro = New System.Windows.Forms.TextBox()
        Me.TxtBxFechaEntrada = New System.Windows.Forms.TextBox()
        Me.LblFechaRegistro = New System.Windows.Forms.Label()
        Me.LblFechaEntrada = New System.Windows.Forms.Label()
        Me.RchTxtBxObservaciones = New System.Windows.Forms.RichTextBox()
        Me.LblObservaciones = New System.Windows.Forms.Label()
        Me.TxtBxNumeroSerie = New System.Windows.Forms.TextBox()
        Me.LblNumeroSerie = New System.Windows.Forms.Label()
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
        Me.RBCompleta = New System.Windows.Forms.RadioButton()
        Me.RBEspecifica = New System.Windows.Forms.RadioButton()
        Me.RBBasica = New System.Windows.Forms.RadioButton()
        Me.TxtBxPeriodoAnalisis = New System.Windows.Forms.TextBox()
        Me.LblPeriodoAnalisis = New System.Windows.Forms.Label()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpBxTipoPrueba.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtBxHoraEntrada
        '
        Me.TxtBxHoraEntrada.Location = New System.Drawing.Point(239, 271)
        Me.TxtBxHoraEntrada.Name = "TxtBxHoraEntrada"
        Me.TxtBxHoraEntrada.ReadOnly = True
        Me.TxtBxHoraEntrada.Size = New System.Drawing.Size(128, 20)
        Me.TxtBxHoraEntrada.TabIndex = 55
        '
        'LblHoraEntrada
        '
        Me.LblHoraEntrada.AutoSize = True
        Me.LblHoraEntrada.Location = New System.Drawing.Point(236, 255)
        Me.LblHoraEntrada.Name = "LblHoraEntrada"
        Me.LblHoraEntrada.Size = New System.Drawing.Size(88, 13)
        Me.LblHoraEntrada.TabIndex = 54
        Me.LblHoraEntrada.Text = "Hora de Entrada:"
        '
        'TxtBxDireccion
        '
        Me.TxtBxDireccion.Location = New System.Drawing.Point(239, 132)
        Me.TxtBxDireccion.Name = "TxtBxDireccion"
        Me.TxtBxDireccion.ReadOnly = True
        Me.TxtBxDireccion.Size = New System.Drawing.Size(128, 20)
        Me.TxtBxDireccion.TabIndex = 53
        '
        'LblDireccion
        '
        Me.LblDireccion.AutoSize = True
        Me.LblDireccion.Location = New System.Drawing.Point(236, 119)
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
        Me.TxtBxTipoProductoID.Location = New System.Drawing.Point(452, 1)
        Me.TxtBxTipoProductoID.Name = "TxtBxTipoProductoID"
        Me.TxtBxTipoProductoID.Size = New System.Drawing.Size(10, 20)
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
        Me.LblUsuario.Size = New System.Drawing.Size(147, 13)
        Me.LblUsuario.TabIndex = 46
        Me.LblUsuario.Text = "Usuario que realizo el reporte:"
        '
        'TxtBxFechaRegistro
        '
        Me.TxtBxFechaRegistro.Location = New System.Drawing.Point(239, 319)
        Me.TxtBxFechaRegistro.Name = "TxtBxFechaRegistro"
        Me.TxtBxFechaRegistro.ReadOnly = True
        Me.TxtBxFechaRegistro.Size = New System.Drawing.Size(128, 20)
        Me.TxtBxFechaRegistro.TabIndex = 45
        '
        'TxtBxFechaEntrada
        '
        Me.TxtBxFechaEntrada.Location = New System.Drawing.Point(239, 225)
        Me.TxtBxFechaEntrada.Name = "TxtBxFechaEntrada"
        Me.TxtBxFechaEntrada.ReadOnly = True
        Me.TxtBxFechaEntrada.Size = New System.Drawing.Size(128, 20)
        Me.TxtBxFechaEntrada.TabIndex = 44
        '
        'LblFechaRegistro
        '
        Me.LblFechaRegistro.AutoSize = True
        Me.LblFechaRegistro.Location = New System.Drawing.Point(236, 303)
        Me.LblFechaRegistro.Name = "LblFechaRegistro"
        Me.LblFechaRegistro.Size = New System.Drawing.Size(97, 13)
        Me.LblFechaRegistro.TabIndex = 43
        Me.LblFechaRegistro.Text = "Fecha de Registro:"
        '
        'LblFechaEntrada
        '
        Me.LblFechaEntrada.AutoSize = True
        Me.LblFechaEntrada.Location = New System.Drawing.Point(236, 207)
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
        Me.RchTxtBxObservaciones.ReadOnly = True
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
        'TxtBxNumeroSerie
        '
        Me.TxtBxNumeroSerie.Location = New System.Drawing.Point(239, 183)
        Me.TxtBxNumeroSerie.Name = "TxtBxNumeroSerie"
        Me.TxtBxNumeroSerie.ReadOnly = True
        Me.TxtBxNumeroSerie.Size = New System.Drawing.Size(128, 20)
        Me.TxtBxNumeroSerie.TabIndex = 39
        '
        'LblNumeroSerie
        '
        Me.LblNumeroSerie.AutoSize = True
        Me.LblNumeroSerie.Location = New System.Drawing.Point(236, 167)
        Me.LblNumeroSerie.Name = "LblNumeroSerie"
        Me.LblNumeroSerie.Size = New System.Drawing.Size(89, 13)
        Me.LblNumeroSerie.TabIndex = 38
        Me.LblNumeroSerie.Text = "Numero de Serie:"
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
        Me.DGV.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(448, 16)
        Me.DGV.Name = "DGV"
        Me.DGV.Size = New System.Drawing.Size(440, 592)
        Me.DGV.TabIndex = 56
        '
        'BtnRechazarReporte
        '
        Me.BtnRechazarReporte.Location = New System.Drawing.Point(385, 656)
        Me.BtnRechazarReporte.Name = "BtnRechazarReporte"
        Me.BtnRechazarReporte.Size = New System.Drawing.Size(75, 40)
        Me.BtnRechazarReporte.TabIndex = 58
        Me.BtnRechazarReporte.Text = "Rechazar Reporte"
        Me.BtnRechazarReporte.UseVisualStyleBackColor = True
        '
        'BtnAceptarReporte
        '
        Me.BtnAceptarReporte.Location = New System.Drawing.Point(304, 656)
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
        'RBCompleta
        '
        Me.RBCompleta.AutoSize = True
        Me.RBCompleta.Location = New System.Drawing.Point(8, 24)
        Me.RBCompleta.Name = "RBCompleta"
        Me.RBCompleta.Size = New System.Drawing.Size(69, 17)
        Me.RBCompleta.TabIndex = 0
        Me.RBCompleta.TabStop = True
        Me.RBCompleta.Text = "Completa"
        Me.RBCompleta.UseVisualStyleBackColor = True
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
        'TxtBxPeriodoAnalisis
        '
        Me.TxtBxPeriodoAnalisis.Location = New System.Drawing.Point(239, 368)
        Me.TxtBxPeriodoAnalisis.Name = "TxtBxPeriodoAnalisis"
        Me.TxtBxPeriodoAnalisis.ReadOnly = True
        Me.TxtBxPeriodoAnalisis.Size = New System.Drawing.Size(128, 20)
        Me.TxtBxPeriodoAnalisis.TabIndex = 61
        '
        'LblPeriodoAnalisis
        '
        Me.LblPeriodoAnalisis.AutoSize = True
        Me.LblPeriodoAnalisis.Location = New System.Drawing.Point(236, 352)
        Me.LblPeriodoAnalisis.Name = "LblPeriodoAnalisis"
        Me.LblPeriodoAnalisis.Size = New System.Drawing.Size(96, 13)
        Me.LblPeriodoAnalisis.TabIndex = 60
        Me.LblPeriodoAnalisis.Text = "Periodo de Analisis"
        '
        'Form5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(893, 707)
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
        Me.Controls.Add(Me.TxtBxFechaRegistro)
        Me.Controls.Add(Me.TxtBxFechaEntrada)
        Me.Controls.Add(Me.LblFechaRegistro)
        Me.Controls.Add(Me.LblFechaEntrada)
        Me.Controls.Add(Me.RchTxtBxObservaciones)
        Me.Controls.Add(Me.LblObservaciones)
        Me.Controls.Add(Me.TxtBxNumeroSerie)
        Me.Controls.Add(Me.LblNumeroSerie)
        Me.Controls.Add(Me.TxtBxProducto)
        Me.Controls.Add(Me.LblTipoMercancia)
        Me.Controls.Add(Me.TxtBxCliente)
        Me.Controls.Add(Me.LblCliente)
        Me.Controls.Add(Me.TxtBxIDProducto)
        Me.Controls.Add(Me.LblIDProducto)
        Me.Name = "Form5"
        Me.Text = "Form5"
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
    Friend WithEvents TxtBxFechaRegistro As TextBox
    Friend WithEvents TxtBxFechaEntrada As TextBox
    Friend WithEvents LblFechaRegistro As Label
    Friend WithEvents LblFechaEntrada As Label
    Friend WithEvents RchTxtBxObservaciones As RichTextBox
    Friend WithEvents LblObservaciones As Label
    Friend WithEvents TxtBxNumeroSerie As TextBox
    Friend WithEvents LblNumeroSerie As Label
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
End Class
