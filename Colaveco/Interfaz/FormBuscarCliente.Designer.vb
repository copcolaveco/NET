<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBuscarCliente
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
        Me.ButtonTodos = New System.Windows.Forms.Button()
        Me.ListClientes = New System.Windows.Forms.ListBox()
        Me.TextBuscar = New System.Windows.Forms.TextBox()
        Me.TextBuscarDicose = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ButtonTodos
        '
        Me.ButtonTodos.Location = New System.Drawing.Point(275, 18)
        Me.ButtonTodos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonTodos.Name = "ButtonTodos"
        Me.ButtonTodos.Size = New System.Drawing.Size(100, 28)
        Me.ButtonTodos.TabIndex = 5
        Me.ButtonTodos.Text = "Todos"
        Me.ButtonTodos.UseVisualStyleBackColor = True
        '
        'ListClientes
        '
        Me.ListClientes.BackColor = System.Drawing.SystemColors.Info
        Me.ListClientes.FormattingEnabled = True
        Me.ListClientes.ItemHeight = 16
        Me.ListClientes.Location = New System.Drawing.Point(16, 117)
        Me.ListClientes.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ListClientes.Name = "ListClientes"
        Me.ListClientes.Size = New System.Drawing.Size(356, 484)
        Me.ListClientes.TabIndex = 4
        '
        'TextBuscar
        '
        Me.TextBuscar.Location = New System.Drawing.Point(16, 35)
        Me.TextBuscar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBuscar.Name = "TextBuscar"
        Me.TextBuscar.Size = New System.Drawing.Size(249, 22)
        Me.TextBuscar.TabIndex = 3
        '
        'TextBuscarDicose
        '
        Me.TextBuscarDicose.Location = New System.Drawing.Point(16, 86)
        Me.TextBuscarDicose.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBuscarDicose.Name = "TextBuscarDicose"
        Me.TextBuscarDicose.Size = New System.Drawing.Size(249, 22)
        Me.TextBuscarDicose.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 17)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Nombre"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Dicose"
        '
        'FormBuscarCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(389, 622)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBuscarDicose)
        Me.Controls.Add(Me.ButtonTodos)
        Me.Controls.Add(Me.ListClientes)
        Me.Controls.Add(Me.TextBuscar)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FormBuscarCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccionar Cliente"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonTodos As System.Windows.Forms.Button
    Friend WithEvents ListClientes As System.Windows.Forms.ListBox
    Friend WithEvents TextBuscar As System.Windows.Forms.TextBox
    Friend WithEvents TextBuscarDicose As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
