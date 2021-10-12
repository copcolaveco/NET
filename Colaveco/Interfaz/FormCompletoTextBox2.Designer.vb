<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCompletoTextBox2
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
        Me.TextResultado2 = New System.Windows.Forms.TextBox()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.TextResultado = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RadioR1 = New System.Windows.Forms.RadioButton()
        Me.RadioR2 = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'TextResultado2
        '
        Me.TextResultado2.Location = New System.Drawing.Point(126, 22)
        Me.TextResultado2.Name = "TextResultado2"
        Me.TextResultado2.Size = New System.Drawing.Size(100, 20)
        Me.TextResultado2.TabIndex = 1
        Me.TextResultado2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(232, 21)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 2
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'TextResultado
        '
        Me.TextResultado.Location = New System.Drawing.Point(11, 22)
        Me.TextResultado.Name = "TextResultado"
        Me.TextResultado.Size = New System.Drawing.Size(100, 20)
        Me.TextResultado.TabIndex = 0
        Me.TextResultado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Base fresca"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(150, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Base seca"
        '
        'RadioR1
        '
        Me.RadioR1.AutoSize = True
        Me.RadioR1.Location = New System.Drawing.Point(12, 48)
        Me.RadioR1.Name = "RadioR1"
        Me.RadioR1.Size = New System.Drawing.Size(106, 17)
        Me.RadioR1.TabIndex = 11
        Me.RadioR1.TabStop = True
        Me.RadioR1.Text = "Mostrar resultado"
        Me.RadioR1.UseVisualStyleBackColor = True
        '
        'RadioR2
        '
        Me.RadioR2.AutoSize = True
        Me.RadioR2.Location = New System.Drawing.Point(126, 48)
        Me.RadioR2.Name = "RadioR2"
        Me.RadioR2.Size = New System.Drawing.Size(106, 17)
        Me.RadioR2.TabIndex = 12
        Me.RadioR2.TabStop = True
        Me.RadioR2.Text = "Mostrar resultado"
        Me.RadioR2.UseVisualStyleBackColor = True
        '
        'FormCompletoTextBox2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(338, 71)
        Me.Controls.Add(Me.RadioR2)
        Me.Controls.Add(Me.RadioR1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextResultado)
        Me.Controls.Add(Me.TextResultado2)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Name = "FormCompletoTextBox2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextResultado2 As System.Windows.Forms.TextBox
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents TextResultado As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RadioR1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioR2 As System.Windows.Forms.RadioButton
End Class
