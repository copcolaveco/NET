<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBuscarEmpresa
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
        Me.ListProductores = New System.Windows.Forms.ListBox
        Me.TextBuscar = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'ButtonTodos
        '
        Me.ButtonTodos.Location = New System.Drawing.Point(206, 5)
        Me.ButtonTodos.Name = "ButtonTodos"
        Me.ButtonTodos.Size = New System.Drawing.Size(75, 23)
        Me.ButtonTodos.TabIndex = 5
        Me.ButtonTodos.Text = "Todos"
        Me.ButtonTodos.UseVisualStyleBackColor = True
        '
        'ListProductores
        '
        Me.ListProductores.BackColor = System.Drawing.SystemColors.Info
        Me.ListProductores.FormattingEnabled = True
        Me.ListProductores.Location = New System.Drawing.Point(12, 33)
        Me.ListProductores.Name = "ListProductores"
        Me.ListProductores.Size = New System.Drawing.Size(268, 446)
        Me.ListProductores.TabIndex = 4
        '
        'TextBuscar
        '
        Me.TextBuscar.Location = New System.Drawing.Point(12, 7)
        Me.TextBuscar.Name = "TextBuscar"
        Me.TextBuscar.Size = New System.Drawing.Size(188, 20)
        Me.TextBuscar.TabIndex = 3
        '
        'FormBuscarEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(297, 486)
        Me.Controls.Add(Me.ButtonTodos)
        Me.Controls.Add(Me.ListProductores)
        Me.Controls.Add(Me.TextBuscar)
        Me.Name = "FormBuscarEmpresa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormBuscarEmpresa"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonTodos As System.Windows.Forms.Button
    Friend WithEvents ListProductores As System.Windows.Forms.ListBox
    Friend WithEvents TextBuscar As System.Windows.Forms.TextBox
End Class
