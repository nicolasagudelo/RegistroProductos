<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form7
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
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.LblIDProducto = New System.Windows.Forms.Label()
        Me.LblPrueba = New System.Windows.Forms.Label()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.DGV.Location = New System.Drawing.Point(12, 71)
        Me.DGV.Name = "DGV"
        Me.DGV.Size = New System.Drawing.Size(553, 378)
        Me.DGV.TabIndex = 57
        '
        'LblIDProducto
        '
        Me.LblIDProducto.AutoSize = True
        Me.LblIDProducto.Location = New System.Drawing.Point(12, 9)
        Me.LblIDProducto.Name = "LblIDProducto"
        Me.LblIDProducto.Size = New System.Drawing.Size(39, 13)
        Me.LblIDProducto.TabIndex = 58
        Me.LblIDProducto.Text = "Label1"
        '
        'LblPrueba
        '
        Me.LblPrueba.AutoSize = True
        Me.LblPrueba.Location = New System.Drawing.Point(12, 40)
        Me.LblPrueba.Name = "LblPrueba"
        Me.LblPrueba.Size = New System.Drawing.Size(39, 13)
        Me.LblPrueba.TabIndex = 59
        Me.LblPrueba.Text = "Label2"
        '
        'Form7
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(577, 461)
        Me.Controls.Add(Me.LblPrueba)
        Me.Controls.Add(Me.LblIDProducto)
        Me.Controls.Add(Me.DGV)
        Me.Name = "Form7"
        Me.Text = "Form7"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DGV As DataGridView
    Friend WithEvents LblIDProducto As Label
    Friend WithEvents LblPrueba As Label
End Class
