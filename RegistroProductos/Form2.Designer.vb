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
        Me.LabelContraseña = New System.Windows.Forms.Label()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.TxBxContraseña = New System.Windows.Forms.TextBox()
        Me.TxtBxUsuario = New System.Windows.Forms.TextBox()
        Me.LblUsuario = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LabelContraseña
        '
        Me.LabelContraseña.AutoSize = True
        Me.LabelContraseña.Location = New System.Drawing.Point(27, 73)
        Me.LabelContraseña.Name = "LabelContraseña"
        Me.LabelContraseña.Size = New System.Drawing.Size(113, 13)
        Me.LabelContraseña.TabIndex = 0
        Me.LabelContraseña.Text = "Ingrese su Contraseña"
        '
        'BtnAceptar
        '
        Me.BtnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnAceptar.Location = New System.Drawing.Point(281, 68)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.BtnAceptar.TabIndex = 3
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.UseVisualStyleBackColor = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancelar.Location = New System.Drawing.Point(281, 95)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancelar.TabIndex = 4
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'TxBxContraseña
        '
        Me.TxBxContraseña.Location = New System.Drawing.Point(30, 98)
        Me.TxBxContraseña.MaxLength = 32
        Me.TxBxContraseña.Name = "TxBxContraseña"
        Me.TxBxContraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxBxContraseña.Size = New System.Drawing.Size(223, 20)
        Me.TxBxContraseña.TabIndex = 2
        '
        'TxtBxUsuario
        '
        Me.TxtBxUsuario.Location = New System.Drawing.Point(30, 41)
        Me.TxtBxUsuario.MaxLength = 32
        Me.TxtBxUsuario.Name = "TxtBxUsuario"
        Me.TxtBxUsuario.Size = New System.Drawing.Size(223, 20)
        Me.TxtBxUsuario.TabIndex = 1
        '
        'LblUsuario
        '
        Me.LblUsuario.AutoSize = True
        Me.LblUsuario.Location = New System.Drawing.Point(27, 16)
        Me.LblUsuario.Name = "LblUsuario"
        Me.LblUsuario.Size = New System.Drawing.Size(95, 13)
        Me.LblUsuario.TabIndex = 0
        Me.LblUsuario.Text = "Ingrese su Usuario"
        '
        'Form2
        '
        Me.AcceptButton = Me.BtnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancelar
        Me.ClientSize = New System.Drawing.Size(368, 147)
        Me.Controls.Add(Me.TxtBxUsuario)
        Me.Controls.Add(Me.LblUsuario)
        Me.Controls.Add(Me.TxBxContraseña)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.LabelContraseña)
        Me.MaximizeBox = False
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Iniciar Sesion"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelContraseña As Label
    Friend WithEvents BtnAceptar As Button
    Friend WithEvents BtnCancelar As Button
    Friend WithEvents TxBxContraseña As TextBox
    Friend WithEvents TxtBxUsuario As TextBox
    Friend WithEvents LblUsuario As Label
End Class
