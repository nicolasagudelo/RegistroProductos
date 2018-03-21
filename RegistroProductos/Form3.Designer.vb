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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
        Me.LblIDProducto = New System.Windows.Forms.Label()
        Me.TxtBxIDProducto = New System.Windows.Forms.TextBox()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.TxtBxCliente = New System.Windows.Forms.TextBox()
        Me.LblTipoMercancia = New System.Windows.Forms.Label()
        Me.TxtBxProducto = New System.Windows.Forms.TextBox()
        Me.LblObservaciones = New System.Windows.Forms.Label()
        Me.RchTxtBxObservaciones = New System.Windows.Forms.RichTextBox()
        Me.LblFechaEntrada = New System.Windows.Forms.Label()
        Me.LblFechaReporte = New System.Windows.Forms.Label()
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
        Me.TxtBxDireccion = New System.Windows.Forms.TextBox()
        Me.LblDireccion = New System.Windows.Forms.Label()
        Me.TxtBxHoraEntrada = New System.Windows.Forms.TextBox()
        Me.LblHoraEntrada = New System.Windows.Forms.Label()
        Me.LblRuta = New System.Windows.Forms.Label()
        Me.TxtBxRuta = New System.Windows.Forms.TextBox()
        Me.BtnEncontrarRuta = New System.Windows.Forms.Button()
        Me.BtnAbrirDatos = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.RBSeleccionarTodo = New System.Windows.Forms.RadioButton()
        Me.RBQuitarTodo = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
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
        Me.LblTipoMercancia.Location = New System.Drawing.Point(12, 108)
        Me.LblTipoMercancia.Name = "LblTipoMercancia"
        Me.LblTipoMercancia.Size = New System.Drawing.Size(53, 13)
        Me.LblTipoMercancia.TabIndex = 7
        Me.LblTipoMercancia.Text = "Producto:"
        '
        'TxtBxProducto
        '
        Me.TxtBxProducto.Location = New System.Drawing.Point(15, 124)
        Me.TxtBxProducto.Name = "TxtBxProducto"
        Me.TxtBxProducto.ReadOnly = True
        Me.TxtBxProducto.Size = New System.Drawing.Size(128, 20)
        Me.TxtBxProducto.TabIndex = 8
        '
        'LblObservaciones
        '
        Me.LblObservaciones.AutoSize = True
        Me.LblObservaciones.Location = New System.Drawing.Point(12, 150)
        Me.LblObservaciones.Name = "LblObservaciones"
        Me.LblObservaciones.Size = New System.Drawing.Size(81, 13)
        Me.LblObservaciones.TabIndex = 11
        Me.LblObservaciones.Text = "Observaciones:"
        '
        'RchTxtBxObservaciones
        '
        Me.RchTxtBxObservaciones.Location = New System.Drawing.Point(15, 166)
        Me.RchTxtBxObservaciones.MaxLength = 150
        Me.RchTxtBxObservaciones.Name = "RchTxtBxObservaciones"
        Me.RchTxtBxObservaciones.Size = New System.Drawing.Size(171, 96)
        Me.RchTxtBxObservaciones.TabIndex = 12
        Me.RchTxtBxObservaciones.Text = ""
        '
        'LblFechaEntrada
        '
        Me.LblFechaEntrada.AutoSize = True
        Me.LblFechaEntrada.Location = New System.Drawing.Point(226, 150)
        Me.LblFechaEntrada.Name = "LblFechaEntrada"
        Me.LblFechaEntrada.Size = New System.Drawing.Size(95, 13)
        Me.LblFechaEntrada.TabIndex = 13
        Me.LblFechaEntrada.Text = "Fecha de Entrada:"
        '
        'LblFechaReporte
        '
        Me.LblFechaReporte.AutoSize = True
        Me.LblFechaReporte.Location = New System.Drawing.Point(224, 228)
        Me.LblFechaReporte.Name = "LblFechaReporte"
        Me.LblFechaReporte.Size = New System.Drawing.Size(96, 13)
        Me.LblFechaReporte.TabIndex = 14
        Me.LblFechaReporte.Text = "Fecha de Reporte:"
        '
        'TxtBxFechaEntrada
        '
        Me.TxtBxFechaEntrada.Location = New System.Drawing.Point(229, 166)
        Me.TxtBxFechaEntrada.Name = "TxtBxFechaEntrada"
        Me.TxtBxFechaEntrada.ReadOnly = True
        Me.TxtBxFechaEntrada.Size = New System.Drawing.Size(128, 20)
        Me.TxtBxFechaEntrada.TabIndex = 15
        '
        'TxtBxFechaRegistro
        '
        Me.TxtBxFechaRegistro.Location = New System.Drawing.Point(227, 244)
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
        Me.Panel1.Location = New System.Drawing.Point(12, 365)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(438, 285)
        Me.Panel1.TabIndex = 21
        '
        'BtnRegistrarReporte
        '
        Me.BtnRegistrarReporte.Location = New System.Drawing.Point(269, 656)
        Me.BtnRegistrarReporte.Name = "BtnRegistrarReporte"
        Me.BtnRegistrarReporte.Size = New System.Drawing.Size(75, 40)
        Me.BtnRegistrarReporte.TabIndex = 22
        Me.BtnRegistrarReporte.Text = "Aceptar"
        Me.BtnRegistrarReporte.UseVisualStyleBackColor = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Location = New System.Drawing.Point(350, 656)
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
        'TxtBxDireccion
        '
        Me.TxtBxDireccion.Location = New System.Drawing.Point(229, 124)
        Me.TxtBxDireccion.Name = "TxtBxDireccion"
        Me.TxtBxDireccion.ReadOnly = True
        Me.TxtBxDireccion.Size = New System.Drawing.Size(128, 20)
        Me.TxtBxDireccion.TabIndex = 27
        '
        'LblDireccion
        '
        Me.LblDireccion.AutoSize = True
        Me.LblDireccion.Location = New System.Drawing.Point(226, 108)
        Me.LblDireccion.Name = "LblDireccion"
        Me.LblDireccion.Size = New System.Drawing.Size(55, 13)
        Me.LblDireccion.TabIndex = 26
        Me.LblDireccion.Text = "Direccion:"
        '
        'TxtBxHoraEntrada
        '
        Me.TxtBxHoraEntrada.Location = New System.Drawing.Point(227, 205)
        Me.TxtBxHoraEntrada.Name = "TxtBxHoraEntrada"
        Me.TxtBxHoraEntrada.ReadOnly = True
        Me.TxtBxHoraEntrada.Size = New System.Drawing.Size(128, 20)
        Me.TxtBxHoraEntrada.TabIndex = 29
        '
        'LblHoraEntrada
        '
        Me.LblHoraEntrada.AutoSize = True
        Me.LblHoraEntrada.Location = New System.Drawing.Point(224, 189)
        Me.LblHoraEntrada.Name = "LblHoraEntrada"
        Me.LblHoraEntrada.Size = New System.Drawing.Size(88, 13)
        Me.LblHoraEntrada.TabIndex = 28
        Me.LblHoraEntrada.Text = "Hora de Entrada:"
        '
        'LblRuta
        '
        Me.LblRuta.AutoSize = True
        Me.LblRuta.Location = New System.Drawing.Point(12, 305)
        Me.LblRuta.Name = "LblRuta"
        Me.LblRuta.Size = New System.Drawing.Size(72, 13)
        Me.LblRuta.TabIndex = 32
        Me.LblRuta.Text = "Cargar Datos:"
        '
        'TxtBxRuta
        '
        Me.TxtBxRuta.Location = New System.Drawing.Point(15, 321)
        Me.TxtBxRuta.Name = "TxtBxRuta"
        Me.TxtBxRuta.ReadOnly = True
        Me.TxtBxRuta.Size = New System.Drawing.Size(340, 20)
        Me.TxtBxRuta.TabIndex = 33
        '
        'BtnEncontrarRuta
        '
        Me.BtnEncontrarRuta.Location = New System.Drawing.Point(361, 321)
        Me.BtnEncontrarRuta.Name = "BtnEncontrarRuta"
        Me.BtnEncontrarRuta.Size = New System.Drawing.Size(25, 20)
        Me.BtnEncontrarRuta.TabIndex = 34
        Me.BtnEncontrarRuta.Text = "..."
        Me.BtnEncontrarRuta.UseVisualStyleBackColor = True
        '
        'BtnAbrirDatos
        '
        Me.BtnAbrirDatos.Location = New System.Drawing.Point(392, 321)
        Me.BtnAbrirDatos.Name = "BtnAbrirDatos"
        Me.BtnAbrirDatos.Size = New System.Drawing.Size(58, 20)
        Me.BtnAbrirDatos.TabIndex = 35
        Me.BtnAbrirDatos.Text = "Abrir"
        Me.BtnAbrirDatos.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 672)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(251, 23)
        Me.ProgressBar1.TabIndex = 36
        '
        'RBSeleccionarTodo
        '
        Me.RBSeleccionarTodo.AutoSize = True
        Me.RBSeleccionarTodo.Location = New System.Drawing.Point(12, 345)
        Me.RBSeleccionarTodo.Name = "RBSeleccionarTodo"
        Me.RBSeleccionarTodo.Size = New System.Drawing.Size(109, 17)
        Me.RBSeleccionarTodo.TabIndex = 37
        Me.RBSeleccionarTodo.TabStop = True
        Me.RBSeleccionarTodo.Text = "Seleccionar Todo"
        Me.RBSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'RBQuitarTodo
        '
        Me.RBQuitarTodo.AutoSize = True
        Me.RBQuitarTodo.Location = New System.Drawing.Point(127, 345)
        Me.RBQuitarTodo.Name = "RBQuitarTodo"
        Me.RBQuitarTodo.Size = New System.Drawing.Size(81, 17)
        Me.RBQuitarTodo.TabIndex = 38
        Me.RBQuitarTodo.TabStop = True
        Me.RBQuitarTodo.Text = "Quitar Todo"
        Me.RBQuitarTodo.UseVisualStyleBackColor = True
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(485, 707)
        Me.Controls.Add(Me.RBQuitarTodo)
        Me.Controls.Add(Me.RBSeleccionarTodo)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.BtnAbrirDatos)
        Me.Controls.Add(Me.BtnEncontrarRuta)
        Me.Controls.Add(Me.TxtBxRuta)
        Me.Controls.Add(Me.LblRuta)
        Me.Controls.Add(Me.TxtBxHoraEntrada)
        Me.Controls.Add(Me.LblHoraEntrada)
        Me.Controls.Add(Me.TxtBxDireccion)
        Me.Controls.Add(Me.LblDireccion)
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
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(501, 746)
        Me.Name = "Form3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Reportar Resultados"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblIDProducto As Label
    Friend WithEvents TxtBxIDProducto As TextBox
    Friend WithEvents LblCliente As Label
    Friend WithEvents TxtBxCliente As TextBox
    Friend WithEvents LblTipoMercancia As Label
    Friend WithEvents TxtBxProducto As TextBox
    Friend WithEvents LblObservaciones As Label
    Friend WithEvents RchTxtBxObservaciones As RichTextBox
    Friend WithEvents LblFechaEntrada As Label
    Friend WithEvents LblFechaReporte As Label
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
    Friend WithEvents TxtBxDireccion As TextBox
    Friend WithEvents LblDireccion As Label
    Friend WithEvents TxtBxHoraEntrada As TextBox
    Friend WithEvents LblHoraEntrada As Label
    Friend WithEvents LblRuta As Label
    Friend WithEvents TxtBxRuta As TextBox
    Friend WithEvents BtnEncontrarRuta As Button
    Friend WithEvents BtnAbrirDatos As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents RBSeleccionarTodo As RadioButton
    Friend WithEvents RBQuitarTodo As RadioButton
End Class
