<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCopiarArchivosCalidad
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
        Me.ButtonCopiar = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'ButtonCopiar
        '
        Me.ButtonCopiar.Location = New System.Drawing.Point(41, 26)
        Me.ButtonCopiar.Name = "ButtonCopiar"
        Me.ButtonCopiar.Size = New System.Drawing.Size(174, 23)
        Me.ButtonCopiar.TabIndex = 0
        Me.ButtonCopiar.Text = "Copiar archivos"
        Me.ButtonCopiar.UseVisualStyleBackColor = True
        '
        'FormCopiarArchivosCalidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(267, 75)
        Me.Controls.Add(Me.ButtonCopiar)
        Me.Name = "FormCopiarArchivosCalidad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Copiar archivos de calidad"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonCopiar As System.Windows.Forms.Button
End Class
