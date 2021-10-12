<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEditarNumeroTambo
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
        Me.TextFicha = New System.Windows.Forms.TextBox
        Me.TextTambo = New System.Windows.Forms.TextBox
        Me.ButtonCambiar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextProductor = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'TextFicha
        '
        Me.TextFicha.Location = New System.Drawing.Point(133, 12)
        Me.TextFicha.Name = "TextFicha"
        Me.TextFicha.Size = New System.Drawing.Size(100, 20)
        Me.TextFicha.TabIndex = 0
        '
        'TextTambo
        '
        Me.TextTambo.Location = New System.Drawing.Point(133, 63)
        Me.TextTambo.Name = "TextTambo"
        Me.TextTambo.Size = New System.Drawing.Size(100, 20)
        Me.TextTambo.TabIndex = 1
        '
        'ButtonCambiar
        '
        Me.ButtonCambiar.Location = New System.Drawing.Point(158, 100)
        Me.ButtonCambiar.Name = "ButtonCambiar"
        Me.ButtonCambiar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCambiar.TabIndex = 2
        Me.ButtonCambiar.Text = "Cambiar"
        Me.ButtonCambiar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Número de ficha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Número de tambo"
        '
        'TextProductor
        '
        Me.TextProductor.Location = New System.Drawing.Point(15, 37)
        Me.TextProductor.Name = "TextProductor"
        Me.TextProductor.ReadOnly = True
        Me.TextProductor.Size = New System.Drawing.Size(218, 20)
        Me.TextProductor.TabIndex = 5
        '
        'FormEditarNumeroTambo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(258, 154)
        Me.Controls.Add(Me.TextProductor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonCambiar)
        Me.Controls.Add(Me.TextTambo)
        Me.Controls.Add(Me.TextFicha)
        Me.Name = "FormEditarNumeroTambo"
        Me.Text = "Editar número de tambo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextFicha As System.Windows.Forms.TextBox
    Friend WithEvents TextTambo As System.Windows.Forms.TextBox
    Friend WithEvents ButtonCambiar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextProductor As System.Windows.Forms.TextBox
End Class
