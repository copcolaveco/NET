<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCompletoATB2
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
        Me.ComboResistencia = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'ComboResistencia
        '
        Me.ComboResistencia.FormattingEnabled = True
        Me.ComboResistencia.Items.AddRange(New Object() {"R", "S", "-"})
        Me.ComboResistencia.Location = New System.Drawing.Point(42, 12)
        Me.ComboResistencia.Name = "ComboResistencia"
        Me.ComboResistencia.Size = New System.Drawing.Size(123, 21)
        Me.ComboResistencia.TabIndex = 2
        '
        'FormCompletoATB2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(209, 52)
        Me.Controls.Add(Me.ComboResistencia)
        Me.Name = "FormCompletoATB2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Completo ATB"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ComboResistencia As System.Windows.Forms.ComboBox
End Class
