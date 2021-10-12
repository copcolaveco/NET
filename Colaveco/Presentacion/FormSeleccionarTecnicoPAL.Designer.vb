<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSeleccionarTecnicoPAL
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
        Me.ButtonGuardar = New System.Windows.Forms.Button
        Me.CheckBoxCecilia = New System.Windows.Forms.CheckBox
        Me.CheckBoxDario = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(88, 80)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 9
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'CheckBoxCecilia
        '
        Me.CheckBoxCecilia.AutoSize = True
        Me.CheckBoxCecilia.Location = New System.Drawing.Point(12, 37)
        Me.CheckBoxCecilia.Name = "CheckBoxCecilia"
        Me.CheckBoxCecilia.Size = New System.Drawing.Size(105, 17)
        Me.CheckBoxCecilia.TabIndex = 6
        Me.CheckBoxCecilia.Text = "Cecilia Abelenda"
        Me.CheckBoxCecilia.UseVisualStyleBackColor = True
        '
        'CheckBoxDario
        '
        Me.CheckBoxDario.AutoSize = True
        Me.CheckBoxDario.Location = New System.Drawing.Point(12, 14)
        Me.CheckBoxDario.Name = "CheckBoxDario"
        Me.CheckBoxDario.Size = New System.Drawing.Size(100, 17)
        Me.CheckBoxDario.TabIndex = 5
        Me.CheckBoxDario.Text = "Darío Hirigoyen"
        Me.CheckBoxDario.UseVisualStyleBackColor = True
        '
        'FormSeleccionarTecnicoPAL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(258, 123)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.CheckBoxCecilia)
        Me.Controls.Add(Me.CheckBoxDario)
        Me.Name = "FormSeleccionarTecnicoPAL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccionar Técnico PAL"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents CheckBoxCecilia As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxDario As System.Windows.Forms.CheckBox
End Class
