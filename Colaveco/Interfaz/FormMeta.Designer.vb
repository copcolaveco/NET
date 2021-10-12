<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMeta
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
        Me.TextMeta = New System.Windows.Forms.TextBox()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.TextId = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'TextMeta
        '
        Me.TextMeta.Location = New System.Drawing.Point(12, 12)
        Me.TextMeta.Multiline = True
        Me.TextMeta.Name = "TextMeta"
        Me.TextMeta.Size = New System.Drawing.Size(274, 76)
        Me.TextMeta.TabIndex = 0
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(211, 94)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 1
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(12, 94)
        Me.TextId.Name = "TextId"
        Me.TextId.Size = New System.Drawing.Size(51, 20)
        Me.TextId.TabIndex = 2
        Me.TextId.Visible = False
        '
        'FormMeta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(298, 129)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.TextMeta)
        Me.Name = "FormMeta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Meta"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextMeta As System.Windows.Forms.TextBox
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents TextId As System.Windows.Forms.TextBox
End Class
