<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCompletoComboBox
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
        Me.ComboResultado = New System.Windows.Forms.ComboBox()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ComboResultado
        '
        Me.ComboResultado.FormattingEnabled = True
        Me.ComboResultado.Location = New System.Drawing.Point(28, 12)
        Me.ComboResultado.Name = "ComboResultado"
        Me.ComboResultado.Size = New System.Drawing.Size(121, 21)
        Me.ComboResultado.TabIndex = 0
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(164, 12)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 1
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'FormCompletoComboBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(279, 48)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ComboResultado)
        Me.Name = "FormCompletoComboBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ComboResultado As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
End Class
