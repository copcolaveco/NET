<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBuscarTecnico
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
        Me.ButtonTodos = New System.Windows.Forms.Button
        Me.ListTecnicos = New System.Windows.Forms.ListBox
        Me.TextBuscar = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'ButtonTodos
        '
        Me.ButtonTodos.Location = New System.Drawing.Point(206, 14)
        Me.ButtonTodos.Name = "ButtonTodos"
        Me.ButtonTodos.Size = New System.Drawing.Size(75, 23)
        Me.ButtonTodos.TabIndex = 5
        Me.ButtonTodos.Text = "Todos"
        Me.ButtonTodos.UseVisualStyleBackColor = True
        '
        'ListTecnicos
        '
        Me.ListTecnicos.FormattingEnabled = True
        Me.ListTecnicos.Location = New System.Drawing.Point(12, 42)
        Me.ListTecnicos.Name = "ListTecnicos"
        Me.ListTecnicos.Size = New System.Drawing.Size(268, 446)
        Me.ListTecnicos.TabIndex = 4
        '
        'TextBuscar
        '
        Me.TextBuscar.Location = New System.Drawing.Point(12, 16)
        Me.TextBuscar.Name = "TextBuscar"
        Me.TextBuscar.Size = New System.Drawing.Size(188, 20)
        Me.TextBuscar.TabIndex = 3
        '
        'FormBuscarTecnico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(293, 500)
        Me.Controls.Add(Me.ButtonTodos)
        Me.Controls.Add(Me.ListTecnicos)
        Me.Controls.Add(Me.TextBuscar)
        Me.Name = "FormBuscarTecnico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar técnico"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonTodos As System.Windows.Forms.Button
    Friend WithEvents ListTecnicos As System.Windows.Forms.ListBox
    Friend WithEvents TextBuscar As System.Windows.Forms.TextBox
End Class
