<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSeleccionarTipoInforme
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
        Me.ComboTI = New System.Windows.Forms.ComboBox()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ComboTI
        '
        Me.ComboTI.FormattingEnabled = True
        Me.ComboTI.Location = New System.Drawing.Point(12, 12)
        Me.ComboTI.Name = "ComboTI"
        Me.ComboTI.Size = New System.Drawing.Size(260, 21)
        Me.ComboTI.TabIndex = 0
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(197, 39)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 1
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'FormSeleccionarTipoInforme
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 73)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ComboTI)
        Me.Name = "FormSeleccionarTipoInforme"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccionar"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ComboTI As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
End Class
