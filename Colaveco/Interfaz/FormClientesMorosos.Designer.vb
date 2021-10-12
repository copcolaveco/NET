<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormClientesMorosos
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
        Me.ButtonBuscar = New System.Windows.Forms.Button()
        Me.TextArchivo = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'ButtonBuscar
        '
        Me.ButtonBuscar.Location = New System.Drawing.Point(15, 12)
        Me.ButtonBuscar.Name = "ButtonBuscar"
        Me.ButtonBuscar.Size = New System.Drawing.Size(112, 23)
        Me.ButtonBuscar.TabIndex = 0
        Me.ButtonBuscar.Text = "Seleccionar archivo"
        Me.ButtonBuscar.UseVisualStyleBackColor = True
        '
        'TextArchivo
        '
        Me.TextArchivo.Location = New System.Drawing.Point(15, 41)
        Me.TextArchivo.Name = "TextArchivo"
        Me.TextArchivo.Size = New System.Drawing.Size(179, 20)
        Me.TextArchivo.TabIndex = 1
        '
        'FormClientesMorosos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(253, 139)
        Me.Controls.Add(Me.TextArchivo)
        Me.Controls.Add(Me.ButtonBuscar)
        Me.Name = "FormClientesMorosos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes Morosos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonBuscar As System.Windows.Forms.Button
    Friend WithEvents TextArchivo As System.Windows.Forms.TextBox
End Class
