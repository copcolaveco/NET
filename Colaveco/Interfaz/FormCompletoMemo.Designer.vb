<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCompletoMemo
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
        Me.TextResultado = New System.Windows.Forms.TextBox()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextResultado
        '
        Me.TextResultado.Location = New System.Drawing.Point(12, 12)
        Me.TextResultado.MaxLength = 1000
        Me.TextResultado.Multiline = True
        Me.TextResultado.Name = "TextResultado"
        Me.TextResultado.Size = New System.Drawing.Size(446, 100)
        Me.TextResultado.TabIndex = 0
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(383, 118)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 1
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'FormCompletoMemo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(470, 155)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.TextResultado)
        Me.Name = "FormCompletoMemo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Completo Memo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextResultado As System.Windows.Forms.TextBox
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
End Class
