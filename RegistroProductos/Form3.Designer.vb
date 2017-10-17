<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form3
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
        Me.CmbBxCategorias = New System.Windows.Forms.ComboBox()
        Me.LblCategoria = New System.Windows.Forms.Label()
        Me.LblIDProducto = New System.Windows.Forms.Label()
        Me.TxtBxIDProducto = New System.Windows.Forms.TextBox()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.TxtBxCliente = New System.Windows.Forms.TextBox()
        Me.LblTipoMercancia = New System.Windows.Forms.Label()
        Me.TxtBxProducto = New System.Windows.Forms.TextBox()
        Me.LblNumeroSerie = New System.Windows.Forms.Label()
        Me.TxtBxNumeroSerie = New System.Windows.Forms.TextBox()
        Me.LblObservaciones = New System.Windows.Forms.Label()
        Me.RchTxtBxObservaciones = New System.Windows.Forms.RichTextBox()
        Me.LblFechaEntrada = New System.Windows.Forms.Label()
        Me.LblFechaRegistro = New System.Windows.Forms.Label()
        Me.TxtBxFechaEntrada = New System.Windows.Forms.TextBox()
        Me.TxtBxFechaRegistro = New System.Windows.Forms.TextBox()
        Me.LblUsuario = New System.Windows.Forms.Label()
        Me.TxtBxUsuario = New System.Windows.Forms.TextBox()
        Me.TxtBxIdUsuario = New System.Windows.Forms.TextBox()
        Me.LblIDUsuario = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnRegistrarReporte = New System.Windows.Forms.Button()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.TxtBxTipoProductoID = New System.Windows.Forms.TextBox()
        Me.TxtBxClienteID = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'CmbBxCategorias
        '
        Me.CmbBxCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBxCategorias.FormattingEnabled = True
        Me.CmbBxCategorias.Location = New System.Drawing.Point(15, 302)
        Me.CmbBxCategorias.Name = "CmbBxCategorias"
        Me.CmbBxCategorias.Size = New System.Drawing.Size(171, 21)
        Me.CmbBxCategorias.TabIndex = 0
        '
        'LblCategoria
        '
        Me.LblCategoria.AutoSize = True
        Me.LblCategoria.Location = New System.Drawing.Point(12, 286)
        Me.LblCategoria.Name = "LblCategoria"
        Me.LblCategoria.Size = New System.Drawing.Size(83, 13)
        Me.LblCategoria.TabIndex = 1
        Me.LblCategoria.Text = "Tipo de Prueba:"
        '
        'LblIDProducto
        '
        Me.LblIDProducto.AutoSize = True
        Me.LblIDProducto.Location = New System.Drawing.Point(12, 56)
        Me.LblIDProducto.Name = "LblIDProducto"
        Me.LblIDProducto.Size = New System.Drawing.Size(85, 26)
        Me.LblIDProducto.TabIndex = 2
        Me.LblIDProducto.Text = "Identificador del " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Producto:"
        '
        'TxtBxIDProducto
        '
        Me.TxtBxIDProducto.Location = New System.Drawing.Point(15, 85)
        Me.TxtBxIDProducto.Name = "TxtBxIDProducto"
        Me.TxtBxIDProducto.ReadOnly = True
        Me.TxtBxIDProducto.Size = New System.Drawing.Size(128, 20)
        Me.TxtBxIDProducto.TabIndex = 3
        '
        'LblCliente
        '
        Me.LblCliente.AutoSize = True
        Me.LblCliente.Location = New System.Drawing.Point(226, 56)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(42, 13)
        Me.LblCliente.TabIndex = 4
        Me.LblCliente.Text = "Cliente:"
        '
        'TxtBxCliente
        '
        Me.TxtBxCliente.Location = New System.Drawing.Point(229, 85)
        Me.TxtBxCliente.Name = "TxtBxCliente"
        Me.TxtBxCliente.ReadOnly = True
        Me.TxtBxCliente.Size = New System.Drawing.Size(128, 20)
        Me.TxtBxCliente.TabIndex = 6
        '
        'LblTipoMercancia
        '
        Me.LblTipoMercancia.AutoSize = True
        Me.LblTipoMercancia.Location = New System.Drawing.Point(12, 118)
        Me.LblTipoMercancia.Name = "LblTipoMercancia"
        Me.LblTipoMercancia.Size = New System.Drawing.Size(53, 13)
        Me.LblTipoMercancia.TabIndex = 7
        Me.LblTipoMercancia.Text = "Producto:"
        '
        'TxtBxProducto
        '
        Me.TxtBxProducto.Location = New System.Drawing.Point(15, 134)
        Me.TxtBxProducto.Name = "TxtBxProducto"
        Me.TxtBxProducto.ReadOnly = True
        Me.TxtBxProducto.Size = New System.Drawing.Size(128, 20)
        Me.TxtBxProducto.TabIndex = 8
        '
        'LblNumeroSerie
        '
        Me.LblNumeroSerie.AutoSize = True
        Me.LblNumeroSerie.Location = New System.Drawing.Point(226, 118)
        Me.LblNumeroSerie.Name = "LblNumeroSerie"
        Me.LblNumeroSerie.Size = New System.Drawing.Size(89, 13)
        Me.LblNumeroSerie.TabIndex = 9
        Me.LblNumeroSerie.Text = "Numero de Serie:"
        '
        'TxtBxNumeroSerie
        '
        Me.TxtBxNumeroSerie.Location = New System.Drawing.Point(229, 134)
        Me.TxtBxNumeroSerie.Name = "TxtBxNumeroSerie"
        Me.TxtBxNumeroSerie.ReadOnly = True
        Me.TxtBxNumeroSerie.Size = New System.Drawing.Size(128, 20)
        Me.TxtBxNumeroSerie.TabIndex = 10
        '
        'LblObservaciones
        '
        Me.LblObservaciones.AutoSize = True
        Me.LblObservaciones.Location = New System.Drawing.Point(12, 168)
        Me.LblObservaciones.Name = "LblObservaciones"
        Me.LblObservaciones.Size = New System.Drawing.Size(81, 13)
        Me.LblObservaciones.TabIndex = 11
        Me.LblObservaciones.Text = "Observaciones:"
        '
        'RchTxtBxObservaciones
        '
        Me.RchTxtBxObservaciones.Location = New System.Drawing.Point(15, 184)
        Me.RchTxtBxObservaciones.MaxLength = 150
        Me.RchTxtBxObservaciones.Name = "RchTxtBxObservaciones"
        Me.RchTxtBxObservaciones.ReadOnly = True
        Me.RchTxtBxObservaciones.Size = New System.Drawing.Size(171, 96)
        Me.RchTxtBxObservaciones.TabIndex = 12
        Me.RchTxtBxObservaciones.Text = ""
        '
        'LblFechaEntrada
        '
        Me.LblFechaEntrada.AutoSize = True
        Me.LblFechaEntrada.Location = New System.Drawing.Point(226, 168)
        Me.LblFechaEntrada.Name = "LblFechaEntrada"
        Me.LblFechaEntrada.Size = New System.Drawing.Size(95, 13)
        Me.LblFechaEntrada.TabIndex = 13
        Me.LblFechaEntrada.Text = "Fecha de Entrada:"
        '
        'LblFechaRegistro
        '
        Me.LblFechaRegistro.AutoSize = True
        Me.LblFechaRegistro.Location = New System.Drawing.Point(226, 220)
        Me.LblFechaRegistro.Name = "LblFechaRegistro"
        Me.LblFechaRegistro.Size = New System.Drawing.Size(97, 13)
        Me.LblFechaRegistro.TabIndex = 14
        Me.LblFechaRegistro.Text = "Fecha de Registro:"
        '
        'TxtBxFechaEntrada
        '
        Me.TxtBxFechaEntrada.Location = New System.Drawing.Point(229, 186)
        Me.TxtBxFechaEntrada.Name = "TxtBxFechaEntrada"
        Me.TxtBxFechaEntrada.ReadOnly = True
        Me.TxtBxFechaEntrada.Size = New System.Drawing.Size(128, 20)
        Me.TxtBxFechaEntrada.TabIndex = 15
        '
        'TxtBxFechaRegistro
        '
        Me.TxtBxFechaRegistro.Location = New System.Drawing.Point(229, 238)
        Me.TxtBxFechaRegistro.Name = "TxtBxFechaRegistro"
        Me.TxtBxFechaRegistro.ReadOnly = True
        Me.TxtBxFechaRegistro.Size = New System.Drawing.Size(128, 20)
        Me.TxtBxFechaRegistro.TabIndex = 16
        '
        'LblUsuario
        '
        Me.LblUsuario.AutoSize = True
        Me.LblUsuario.Location = New System.Drawing.Point(12, 9)
        Me.LblUsuario.Name = "LblUsuario"
        Me.LblUsuario.Size = New System.Drawing.Size(46, 13)
        Me.LblUsuario.TabIndex = 17
        Me.LblUsuario.Text = "Usuario:"
        '
        'TxtBxUsuario
        '
        Me.TxtBxUsuario.Location = New System.Drawing.Point(15, 25)
        Me.TxtBxUsuario.Name = "TxtBxUsuario"
        Me.TxtBxUsuario.ReadOnly = True
        Me.TxtBxUsuario.Size = New System.Drawing.Size(128, 20)
        Me.TxtBxUsuario.TabIndex = 18
        '
        'TxtBxIdUsuario
        '
        Me.TxtBxIdUsuario.Location = New System.Drawing.Point(229, 25)
        Me.TxtBxIdUsuario.MaximumSize = New System.Drawing.Size(128, 20)
        Me.TxtBxIdUsuario.MinimumSize = New System.Drawing.Size(128, 20)
        Me.TxtBxIdUsuario.Name = "TxtBxIdUsuario"
        Me.TxtBxIdUsuario.ReadOnly = True
        Me.TxtBxIdUsuario.Size = New System.Drawing.Size(128, 20)
        Me.TxtBxIdUsuario.TabIndex = 20
        '
        'LblIDUsuario
        '
        Me.LblIDUsuario.AutoSize = True
        Me.LblIDUsuario.Location = New System.Drawing.Point(226, 9)
        Me.LblIDUsuario.Name = "LblIDUsuario"
        Me.LblIDUsuario.Size = New System.Drawing.Size(60, 13)
        Me.LblIDUsuario.TabIndex = 19
        Me.LblIDUsuario.Text = "ID Usuario:"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Location = New System.Drawing.Point(12, 342)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(438, 285)
        Me.Panel1.TabIndex = 21
        '
        'BtnRegistrarReporte
        '
        Me.BtnRegistrarReporte.Location = New System.Drawing.Point(269, 633)
        Me.BtnRegistrarReporte.Name = "BtnRegistrarReporte"
        Me.BtnRegistrarReporte.Size = New System.Drawing.Size(75, 40)
        Me.BtnRegistrarReporte.TabIndex = 22
        Me.BtnRegistrarReporte.Text = "Aceptar"
        Me.BtnRegistrarReporte.UseVisualStyleBackColor = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Location = New System.Drawing.Point(350, 633)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(75, 40)
        Me.BtnCancelar.TabIndex = 23
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'TxtBxTipoProductoID
        '
        Me.TxtBxTipoProductoID.Location = New System.Drawing.Point(440, 2)
        Me.TxtBxTipoProductoID.Name = "TxtBxTipoProductoID"
        Me.TxtBxTipoProductoID.Size = New System.Drawing.Size(10, 20)
        Me.TxtBxTipoProductoID.TabIndex = 24
        Me.TxtBxTipoProductoID.Visible = False
        '
        'TxtBxClienteID
        '
        Me.TxtBxClienteID.Location = New System.Drawing.Point(440, 25)
        Me.TxtBxClienteID.Name = "TxtBxClienteID"
        Me.TxtBxClienteID.Size = New System.Drawing.Size(10, 20)
        Me.TxtBxClienteID.TabIndex = 25
        Me.TxtBxClienteID.Visible = False
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(485, 685)
        Me.Controls.Add(Me.TxtBxClienteID)
        Me.Controls.Add(Me.TxtBxTipoProductoID)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnRegistrarReporte)
        Me.Controls.Add(Me.Panel1)
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
        Me.Controls.Add(Me.LblCategoria)
        Me.Controls.Add(Me.CmbBxCategorias)
        Me.Name = "Form3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form3"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CmbBxCategorias As ComboBox
    Friend WithEvents LblCategoria As Label
    Friend WithEvents LblIDProducto As Label
    Friend WithEvents TxtBxIDProducto As TextBox
    Friend WithEvents LblCliente As Label
    Friend WithEvents TxtBxCliente As TextBox
    Friend WithEvents LblTipoMercancia As Label
    Friend WithEvents TxtBxProducto As TextBox
    Friend WithEvents LblNumeroSerie As Label
    Friend WithEvents TxtBxNumeroSerie As TextBox
    Friend WithEvents LblObservaciones As Label
    Friend WithEvents RchTxtBxObservaciones As RichTextBox
    Friend WithEvents LblFechaEntrada As Label
    Friend WithEvents LblFechaRegistro As Label
    Friend WithEvents TxtBxFechaEntrada As TextBox
    Friend WithEvents TxtBxFechaRegistro As TextBox
    Friend WithEvents LblUsuario As Label
    Friend WithEvents TxtBxUsuario As TextBox
    Friend WithEvents TxtBxIdUsuario As TextBox
    Friend WithEvents LblIDUsuario As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnRegistrarReporte As Button
    Friend WithEvents BtnCancelar As Button
    Friend WithEvents TxtBxTipoProductoID As TextBox
    Friend WithEvents TxtBxClienteID As TextBox
End Class
