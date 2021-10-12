<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAntibiograma2
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
        Me.CheckAislamiento = New System.Windows.Forms.CheckBox
        Me.CheckAntibiograma = New System.Windows.Forms.CheckBox
        Me.ButtonGuardar = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'CheckAislamiento
        '
        Me.CheckAislamiento.AutoSize = True
        Me.CheckAislamiento.Location = New System.Drawing.Point(12, 12)
        Me.CheckAislamiento.Name = "CheckAislamiento"
        Me.CheckAislamiento.Size = New System.Drawing.Size(123, 17)
        Me.CheckAislamiento.TabIndex = 0
        Me.CheckAislamiento.Text = "Aislamiento y células"
        Me.CheckAislamiento.UseVisualStyleBackColor = True
        '
        'CheckAntibiograma
        '
        Me.CheckAntibiograma.AutoSize = True
        Me.CheckAntibiograma.Location = New System.Drawing.Point(12, 45)
        Me.CheckAntibiograma.Name = "CheckAntibiograma"
        Me.CheckAntibiograma.Size = New System.Drawing.Size(87, 17)
        Me.CheckAntibiograma.TabIndex = 1
        Me.CheckAntibiograma.Text = "Antibiograma"
        Me.CheckAntibiograma.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(12, 78)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 2
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'FormAntibiograma2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(199, 113)
        Me.ControlBox = False
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.CheckAntibiograma)
        Me.Controls.Add(Me.CheckAislamiento)
        Me.Name = "FormAntibiograma2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Antibiograma"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CheckAislamiento As System.Windows.Forms.CheckBox
    Friend WithEvents CheckAntibiograma As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
End Class
