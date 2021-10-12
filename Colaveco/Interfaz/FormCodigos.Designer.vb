<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCodigos
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
        Me.ComboCodigo = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'ComboCodigo
        '
        Me.ComboCodigo.FormattingEnabled = True
        Me.ComboCodigo.Items.AddRange(New Object() {"E", "M", "P", "I"})
        Me.ComboCodigo.Location = New System.Drawing.Point(12, 12)
        Me.ComboCodigo.Name = "ComboCodigo"
        Me.ComboCodigo.Size = New System.Drawing.Size(98, 21)
        Me.ComboCodigo.TabIndex = 0
        '
        'FormCodigos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(181, 47)
        Me.Controls.Add(Me.ComboCodigo)
        Me.Name = "FormCodigos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Códigos"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ComboCodigo As System.Windows.Forms.ComboBox
End Class
