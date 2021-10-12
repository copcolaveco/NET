<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCompletoLaboratorio
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
        Me.ComboLaboratorio = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(223, 12)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 3
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ComboLaboratorio
        '
        Me.ComboLaboratorio.FormattingEnabled = True
        Me.ComboLaboratorio.Location = New System.Drawing.Point(12, 12)
        Me.ComboLaboratorio.Name = "ComboLaboratorio"
        Me.ComboLaboratorio.Size = New System.Drawing.Size(205, 21)
        Me.ComboLaboratorio.TabIndex = 2
        '
        'FormCompletoLaboratorio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(319, 55)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ComboLaboratorio)
        Me.Name = "FormCompletoLaboratorio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccionar laboratorio"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ComboLaboratorio As System.Windows.Forms.ComboBox
End Class
