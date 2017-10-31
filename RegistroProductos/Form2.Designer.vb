<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Usuario = New System.Windows.Forms.TabPage()
        Me.TxtBxUsuario = New System.Windows.Forms.TextBox()
        Me.LblUsuario = New System.Windows.Forms.Label()
        Me.TxBxContraseña = New System.Windows.Forms.TextBox()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.LabelContraseña = New System.Windows.Forms.Label()
        Me.Cliente = New System.Windows.Forms.TabPage()
        Me.CmbBxCliente = New System.Windows.Forms.ComboBox()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.TxtBxContraseñaCliente = New System.Windows.Forms.TextBox()
        Me.BtnCancelarCliente = New System.Windows.Forms.Button()
        Me.BtnAceptarCliente = New System.Windows.Forms.Button()
        Me.LblContraseñaCliente = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.Usuario.SuspendLayout()
        Me.Cliente.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Usuario)
        Me.TabControl1.Controls.Add(Me.Cliente)
        Me.TabControl1.HotTrack = True
        Me.TabControl1.Location = New System.Drawing.Point(2, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(370, 156)
        Me.TabControl1.TabIndex = 5
        '
        'Usuario
        '
        Me.Usuario.BackColor = System.Drawing.SystemColors.Control
        Me.Usuario.Controls.Add(Me.TxtBxUsuario)
        Me.Usuario.Controls.Add(Me.LblUsuario)
        Me.Usuario.Controls.Add(Me.TxBxContraseña)
        Me.Usuario.Controls.Add(Me.BtnCancelar)
        Me.Usuario.Controls.Add(Me.BtnAceptar)
        Me.Usuario.Controls.Add(Me.LabelContraseña)
        Me.Usuario.Location = New System.Drawing.Point(4, 22)
        Me.Usuario.Name = "Usuario"
        Me.Usuario.Padding = New System.Windows.Forms.Padding(3)
        Me.Usuario.Size = New System.Drawing.Size(362, 130)
        Me.Usuario.TabIndex = 0
        Me.Usuario.Text = "Usuario"
        '
        'TxtBxUsuario
        '
        Me.TxtBxUsuario.Location = New System.Drawing.Point(20, 33)
        Me.TxtBxUsuario.MaxLength = 32
        Me.TxtBxUsuario.Name = "TxtBxUsuario"
        Me.TxtBxUsuario.Size = New System.Drawing.Size(223, 20)
        Me.TxtBxUsuario.TabIndex = 7
        '
        'LblUsuario
        '
        Me.LblUsuario.AutoSize = True
        Me.LblUsuario.Location = New System.Drawing.Point(17, 8)
        Me.LblUsuario.Name = "LblUsuario"
        Me.LblUsuario.Size = New System.Drawing.Size(95, 13)
        Me.LblUsuario.TabIndex = 5
        Me.LblUsuario.Text = "Ingrese su Usuario"
        '
        'TxBxContraseña
        '
        Me.TxBxContraseña.Location = New System.Drawing.Point(20, 90)
        Me.TxBxContraseña.MaxLength = 32
        Me.TxBxContraseña.Name = "TxBxContraseña"
        Me.TxBxContraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxBxContraseña.Size = New System.Drawing.Size(223, 20)
        Me.TxBxContraseña.TabIndex = 8
        '
        'BtnCancelar
        '
        Me.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancelar.Location = New System.Drawing.Point(271, 87)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancelar.TabIndex = 10
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'BtnAceptar
        '
        Me.BtnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnAceptar.Location = New System.Drawing.Point(271, 60)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.BtnAceptar.TabIndex = 9
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.UseVisualStyleBackColor = True
        '
        'LabelContraseña
        '
        Me.LabelContraseña.AutoSize = True
        Me.LabelContraseña.Location = New System.Drawing.Point(17, 65)
        Me.LabelContraseña.Name = "LabelContraseña"
        Me.LabelContraseña.Size = New System.Drawing.Size(113, 13)
        Me.LabelContraseña.TabIndex = 6
        Me.LabelContraseña.Text = "Ingrese su Contraseña"
        '
        'Cliente
        '
        Me.Cliente.AllowDrop = True
        Me.Cliente.BackColor = System.Drawing.SystemColors.Control
        Me.Cliente.Controls.Add(Me.CmbBxCliente)
        Me.Cliente.Controls.Add(Me.LblCliente)
        Me.Cliente.Controls.Add(Me.TxtBxContraseñaCliente)
        Me.Cliente.Controls.Add(Me.BtnCancelarCliente)
        Me.Cliente.Controls.Add(Me.BtnAceptarCliente)
        Me.Cliente.Controls.Add(Me.LblContraseñaCliente)
        Me.Cliente.Location = New System.Drawing.Point(4, 22)
        Me.Cliente.Name = "Cliente"
        Me.Cliente.Padding = New System.Windows.Forms.Padding(3)
        Me.Cliente.Size = New System.Drawing.Size(362, 130)
        Me.Cliente.TabIndex = 1
        Me.Cliente.Text = "Cliente"
        '
        'CmbBxCliente
        '
        Me.CmbBxCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBxCliente.FormattingEnabled = True
        Me.CmbBxCliente.Location = New System.Drawing.Point(20, 32)
        Me.CmbBxCliente.Name = "CmbBxCliente"
        Me.CmbBxCliente.Size = New System.Drawing.Size(223, 21)
        Me.CmbBxCliente.TabIndex = 17
        '
        'LblCliente
        '
        Me.LblCliente.AutoSize = True
        Me.LblCliente.Location = New System.Drawing.Point(17, 8)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(42, 13)
        Me.LblCliente.TabIndex = 11
        Me.LblCliente.Text = "Cliente:"
        '
        'TxtBxContraseñaCliente
        '
        Me.TxtBxContraseñaCliente.Location = New System.Drawing.Point(20, 90)
        Me.TxtBxContraseñaCliente.MaxLength = 32
        Me.TxtBxContraseñaCliente.Name = "TxtBxContraseñaCliente"
        Me.TxtBxContraseñaCliente.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtBxContraseñaCliente.Size = New System.Drawing.Size(223, 20)
        Me.TxtBxContraseñaCliente.TabIndex = 14
        '
        'BtnCancelarCliente
        '
        Me.BtnCancelarCliente.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancelarCliente.Location = New System.Drawing.Point(271, 87)
        Me.BtnCancelarCliente.Name = "BtnCancelarCliente"
        Me.BtnCancelarCliente.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancelarCliente.TabIndex = 16
        Me.BtnCancelarCliente.Text = "Cancelar"
        Me.BtnCancelarCliente.UseVisualStyleBackColor = True
        '
        'BtnAceptarCliente
        '
        Me.BtnAceptarCliente.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnAceptarCliente.Location = New System.Drawing.Point(271, 60)
        Me.BtnAceptarCliente.Name = "BtnAceptarCliente"
        Me.BtnAceptarCliente.Size = New System.Drawing.Size(75, 23)
        Me.BtnAceptarCliente.TabIndex = 15
        Me.BtnAceptarCliente.Text = "Aceptar"
        Me.BtnAceptarCliente.UseVisualStyleBackColor = True
        '
        'LblContraseñaCliente
        '
        Me.LblContraseñaCliente.AutoSize = True
        Me.LblContraseñaCliente.Location = New System.Drawing.Point(17, 65)
        Me.LblContraseñaCliente.Name = "LblContraseñaCliente"
        Me.LblContraseñaCliente.Size = New System.Drawing.Size(113, 13)
        Me.LblContraseñaCliente.TabIndex = 12
        Me.LblContraseñaCliente.Text = "Ingrese su Contraseña"
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(373, 161)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Iniciar Sesion"
        Me.TabControl1.ResumeLayout(False)
        Me.Usuario.ResumeLayout(False)
        Me.Usuario.PerformLayout()
        Me.Cliente.ResumeLayout(False)
        Me.Cliente.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents Usuario As TabPage
    Friend WithEvents TxtBxUsuario As TextBox
    Friend WithEvents LblUsuario As Label
    Friend WithEvents TxBxContraseña As TextBox
    Friend WithEvents BtnCancelar As Button
    Friend WithEvents BtnAceptar As Button
    Friend WithEvents LabelContraseña As Label
    Friend WithEvents Cliente As TabPage
    Friend WithEvents CmbBxCliente As ComboBox
    Friend WithEvents LblCliente As Label
    Friend WithEvents TxtBxContraseñaCliente As TextBox
    Friend WithEvents BtnCancelarCliente As Button
    Friend WithEvents BtnAceptarCliente As Button
    Friend WithEvents LblContraseñaCliente As Label
End Class
