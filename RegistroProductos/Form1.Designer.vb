<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LblNumeroProducto = New System.Windows.Forms.Label()
        Me.TxtBxProductoID = New System.Windows.Forms.TextBox()
        Me.DGVProductosSinRevisar = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.DGVProductosLimite = New System.Windows.Forms.DataGridView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.LabelUsuario = New System.Windows.Forms.Label()
        Me.BtnDesconectar = New System.Windows.Forms.Button()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.CmbBxClientes = New System.Windows.Forms.ComboBox()
        Me.LblTipoProducto = New System.Windows.Forms.Label()
        Me.TxtBxNumeroSerie = New System.Windows.Forms.TextBox()
        Me.CmbBxTipoProducto = New System.Windows.Forms.ComboBox()
        Me.LblNumeroSerie = New System.Windows.Forms.Label()
        Me.LblObservaciones = New System.Windows.Forms.Label()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DGVProductosSinRevisar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.DGVProductosLimite, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(0, 24)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1015, 460)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.DGVProductosSinRevisar)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1007, 434)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Registrar Producto"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.RichTextBox1)
        Me.Panel1.Controls.Add(Me.LblObservaciones)
        Me.Panel1.Controls.Add(Me.LblNumeroSerie)
        Me.Panel1.Controls.Add(Me.CmbBxTipoProducto)
        Me.Panel1.Controls.Add(Me.TxtBxNumeroSerie)
        Me.Panel1.Controls.Add(Me.LblTipoProducto)
        Me.Panel1.Controls.Add(Me.CmbBxClientes)
        Me.Panel1.Controls.Add(Me.LblCliente)
        Me.Panel1.Controls.Add(Me.LblNumeroProducto)
        Me.Panel1.Controls.Add(Me.TxtBxProductoID)
        Me.Panel1.Location = New System.Drawing.Point(8, 287)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(993, 137)
        Me.Panel1.TabIndex = 1
        '
        'LblNumeroProducto
        '
        Me.LblNumeroProducto.AutoSize = True
        Me.LblNumeroProducto.Location = New System.Drawing.Point(10, 11)
        Me.LblNumeroProducto.Name = "LblNumeroProducto"
        Me.LblNumeroProducto.Size = New System.Drawing.Size(85, 26)
        Me.LblNumeroProducto.TabIndex = 1
        Me.LblNumeroProducto.Text = "Identificador del " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "producto:"
        '
        'TxtBxProductoID
        '
        Me.TxtBxProductoID.Location = New System.Drawing.Point(13, 40)
        Me.TxtBxProductoID.Name = "TxtBxProductoID"
        Me.TxtBxProductoID.Size = New System.Drawing.Size(121, 20)
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
        Me.DGVProductosSinRevisar.Location = New System.Drawing.Point(3, 3)
        Me.DGVProductosSinRevisar.Name = "DGVProductosSinRevisar"
        Me.DGVProductosSinRevisar.Size = New System.Drawing.Size(998, 278)
        Me.DGVProductosSinRevisar.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.DGVProductosLimite)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1007, 434)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Productos Limite"
        Me.TabPage2.UseVisualStyleBackColor = True
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
        Me.DGVProductosLimite.Location = New System.Drawing.Point(3, 3)
        Me.DGVProductosLimite.Name = "DGVProductosLimite"
        Me.DGVProductosLimite.Size = New System.Drawing.Size(998, 254)
        Me.DGVProductosLimite.TabIndex = 2
        '
        'TabPage3
        '
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1007, 434)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Reportar Resultados."
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'LabelUsuario
        '
        Me.LabelUsuario.AutoSize = True
        Me.LabelUsuario.BackColor = System.Drawing.SystemColors.ControlLight
        Me.LabelUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelUsuario.ForeColor = System.Drawing.Color.Red
        Me.LabelUsuario.Location = New System.Drawing.Point(4, 4)
        Me.LabelUsuario.Name = "LabelUsuario"
        Me.LabelUsuario.Size = New System.Drawing.Size(57, 17)
        Me.LabelUsuario.TabIndex = 3
        Me.LabelUsuario.Text = "Label1"
        '
        'BtnDesconectar
        '
        Me.BtnDesconectar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDesconectar.Location = New System.Drawing.Point(921, 1)
        Me.BtnDesconectar.Name = "BtnDesconectar"
        Me.BtnDesconectar.Size = New System.Drawing.Size(90, 23)
        Me.BtnDesconectar.TabIndex = 4
        Me.BtnDesconectar.Text = "Cerrar Sesion"
        Me.BtnDesconectar.UseVisualStyleBackColor = True
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
        'CmbBxClientes
        '
        Me.CmbBxClientes.FormattingEnabled = True
        Me.CmbBxClientes.Location = New System.Drawing.Point(13, 87)
        Me.CmbBxClientes.Name = "CmbBxClientes"
        Me.CmbBxClientes.Size = New System.Drawing.Size(121, 21)
        Me.CmbBxClientes.TabIndex = 3
        '
        'LblTipoProducto
        '
        Me.LblTipoProducto.AutoSize = True
        Me.LblTipoProducto.Location = New System.Drawing.Point(155, 71)
        Me.LblTipoProducto.Name = "LblTipoProducto"
        Me.LblTipoProducto.Size = New System.Drawing.Size(53, 13)
        Me.LblTipoProducto.TabIndex = 4
        Me.LblTipoProducto.Text = "Producto:"
        '
        'TxtBxNumeroSerie
        '
        Me.TxtBxNumeroSerie.Location = New System.Drawing.Point(158, 40)
        Me.TxtBxNumeroSerie.Name = "TxtBxNumeroSerie"
        Me.TxtBxNumeroSerie.Size = New System.Drawing.Size(121, 20)
        Me.TxtBxNumeroSerie.TabIndex = 5
        '
        'CmbBxTipoProducto
        '
        Me.CmbBxTipoProducto.FormattingEnabled = True
        Me.CmbBxTipoProducto.Location = New System.Drawing.Point(158, 87)
        Me.CmbBxTipoProducto.Name = "CmbBxTipoProducto"
        Me.CmbBxTipoProducto.Size = New System.Drawing.Size(121, 21)
        Me.CmbBxTipoProducto.TabIndex = 6
        '
        'LblNumeroSerie
        '
        Me.LblNumeroSerie.AutoSize = True
        Me.LblNumeroSerie.Location = New System.Drawing.Point(155, 11)
        Me.LblNumeroSerie.Name = "LblNumeroSerie"
        Me.LblNumeroSerie.Size = New System.Drawing.Size(89, 13)
        Me.LblNumeroSerie.TabIndex = 7
        Me.LblNumeroSerie.Text = "Numero de Serie:"
        '
        'LblObservaciones
        '
        Me.LblObservaciones.AutoSize = True
        Me.LblObservaciones.Location = New System.Drawing.Point(308, 11)
        Me.LblObservaciones.Name = "LblObservaciones"
        Me.LblObservaciones.Size = New System.Drawing.Size(78, 13)
        Me.LblObservaciones.TabIndex = 8
        Me.LblObservaciones.Text = "Observaciones"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(311, 40)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(211, 68)
        Me.RichTextBox1.TabIndex = 9
        Me.RichTextBox1.Text = ""
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(1017, 482)
        Me.Controls.Add(Me.BtnDesconectar)
        Me.Controls.Add(Me.LabelUsuario)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DGVProductosSinRevisar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.DGVProductosLimite, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents DGVProductosSinRevisar As DataGridView
    Friend WithEvents DGVProductosLimite As DataGridView
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents LabelUsuario As Label
    Friend WithEvents BtnDesconectar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LblNumeroProducto As Label
    Friend WithEvents TxtBxProductoID As TextBox
    Friend WithEvents CmbBxClientes As ComboBox
    Friend WithEvents LblCliente As Label
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents LblObservaciones As Label
    Friend WithEvents LblNumeroSerie As Label
    Friend WithEvents CmbBxTipoProducto As ComboBox
    Friend WithEvents TxtBxNumeroSerie As TextBox
    Friend WithEvents LblTipoProducto As Label
End Class
