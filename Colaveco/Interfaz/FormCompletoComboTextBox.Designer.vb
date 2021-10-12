<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCompletoComboTextBox
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
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.ComboResultado = New System.Windows.Forms.ComboBox()
        Me.TextResultado = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(246, 15)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 2
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ComboResultado
        '
        Me.ComboResultado.FormattingEnabled = True
        Me.ComboResultado.Location = New System.Drawing.Point(13, 15)
        Me.ComboResultado.Name = "ComboResultado"
        Me.ComboResultado.Size = New System.Drawing.Size(121, 21)
        Me.ComboResultado.TabIndex = 0
        '
        'TextResultado
        '
        Me.TextResultado.Location = New System.Drawing.Point(140, 16)
        Me.TextResultado.Name = "TextResultado"
        Me.TextResultado.Size = New System.Drawing.Size(100, 20)
        Me.TextResultado.TabIndex = 1
        '
        'FormCompletoComboTextBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(342, 48)
        Me.Controls.Add(Me.TextResultado)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ComboResultado)
        Me.Name = "FormCompletoComboTextBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ComboResultado As System.Windows.Forms.ComboBox
    Friend WithEvents TextResultado As System.Windows.Forms.TextBox
End Class
