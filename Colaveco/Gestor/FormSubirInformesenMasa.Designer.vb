<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSubirInformesenMasa
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
        Me.ButtonCambiarEstado = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboEstado = New System.Windows.Forms.ComboBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'ButtonCambiarEstado
        '
        Me.ButtonCambiarEstado.Location = New System.Drawing.Point(12, 54)
        Me.ButtonCambiarEstado.Name = "ButtonCambiarEstado"
        Me.ButtonCambiarEstado.Size = New System.Drawing.Size(147, 23)
        Me.ButtonCambiarEstado.TabIndex = 72
        Me.ButtonCambiarEstado.Text = "Cambiar estado"
        Me.ButtonCambiarEstado.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(50, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 70
        Me.Label5.Text = "Estado"
        '
        'ComboEstado
        '
        Me.ComboEstado.FormattingEnabled = True
        Me.ComboEstado.Items.AddRange(New Object() {"Abonado", "No abonado (con visualización)", "No abonado (sin visualización)"})
        Me.ComboEstado.Location = New System.Drawing.Point(12, 27)
        Me.ComboEstado.Name = "ComboEstado"
        Me.ComboEstado.Size = New System.Drawing.Size(121, 21)
        Me.ComboEstado.TabIndex = 62
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(175, 27)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(168, 368)
        Me.ListBox1.TabIndex = 73
        '
        'FormSubirInformesenMasa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(359, 418)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.ButtonCambiarEstado)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ComboEstado)
        Me.Name = "FormSubirInformesenMasa"
        Me.Text = "FormSubirInformesenMasa"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonCambiarEstado As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
End Class
