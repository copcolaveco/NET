<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTecnicoProductor
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
        Me.DataGridTecnicos = New System.Windows.Forms.DataGridView
        Me.IdTecnico = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NombreTecnico = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridProductores = New System.Windows.Forms.DataGridView
        Me.TextBuscarTecnico = New System.Windows.Forms.TextBox
        Me.TextBuscarProductor = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.IdProductor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NombreProductor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ButtonTodosTecnicos = New System.Windows.Forms.Button
        Me.ButtonTodosProductores = New System.Windows.Forms.Button
        CType(Me.DataGridTecnicos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridProductores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridTecnicos
        '
        Me.DataGridTecnicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridTecnicos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdTecnico, Me.NombreTecnico})
        Me.DataGridTecnicos.Location = New System.Drawing.Point(12, 58)
        Me.DataGridTecnicos.Name = "DataGridTecnicos"
        Me.DataGridTecnicos.RowHeadersVisible = False
        Me.DataGridTecnicos.Size = New System.Drawing.Size(270, 491)
        Me.DataGridTecnicos.TabIndex = 0
        '
        'IdTecnico
        '
        Me.IdTecnico.HeaderText = "ID"
        Me.IdTecnico.Name = "IdTecnico"
        Me.IdTecnico.Visible = False
        '
        'NombreTecnico
        '
        Me.NombreTecnico.HeaderText = "Nombre"
        Me.NombreTecnico.Name = "NombreTecnico"
        Me.NombreTecnico.Width = 250
        '
        'DataGridProductores
        '
        Me.DataGridProductores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridProductores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdProductor, Me.NombreProductor})
        Me.DataGridProductores.Location = New System.Drawing.Point(302, 58)
        Me.DataGridProductores.Name = "DataGridProductores"
        Me.DataGridProductores.RowHeadersVisible = False
        Me.DataGridProductores.Size = New System.Drawing.Size(270, 491)
        Me.DataGridProductores.TabIndex = 1
        '
        'TextBuscarTecnico
        '
        Me.TextBuscarTecnico.Location = New System.Drawing.Point(12, 32)
        Me.TextBuscarTecnico.Name = "TextBuscarTecnico"
        Me.TextBuscarTecnico.Size = New System.Drawing.Size(270, 20)
        Me.TextBuscarTecnico.TabIndex = 2
        '
        'TextBuscarProductor
        '
        Me.TextBuscarProductor.Location = New System.Drawing.Point(302, 32)
        Me.TextBuscarProductor.Name = "TextBuscarProductor"
        Me.TextBuscarProductor.Size = New System.Drawing.Size(270, 20)
        Me.TextBuscarProductor.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Técnico"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(299, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Productor"
        '
        'IdProductor
        '
        Me.IdProductor.HeaderText = "ID"
        Me.IdProductor.Name = "IdProductor"
        Me.IdProductor.Visible = False
        '
        'NombreProductor
        '
        Me.NombreProductor.HeaderText = "Nombre"
        Me.NombreProductor.Name = "NombreProductor"
        Me.NombreProductor.Width = 250
        '
        'ButtonTodosTecnicos
        '
        Me.ButtonTodosTecnicos.Location = New System.Drawing.Point(207, 3)
        Me.ButtonTodosTecnicos.Name = "ButtonTodosTecnicos"
        Me.ButtonTodosTecnicos.Size = New System.Drawing.Size(75, 23)
        Me.ButtonTodosTecnicos.TabIndex = 6
        Me.ButtonTodosTecnicos.Text = "Todos"
        Me.ButtonTodosTecnicos.UseVisualStyleBackColor = True
        '
        'ButtonTodosProductores
        '
        Me.ButtonTodosProductores.Location = New System.Drawing.Point(497, 3)
        Me.ButtonTodosProductores.Name = "ButtonTodosProductores"
        Me.ButtonTodosProductores.Size = New System.Drawing.Size(75, 23)
        Me.ButtonTodosProductores.TabIndex = 7
        Me.ButtonTodosProductores.Text = "Todos"
        Me.ButtonTodosProductores.UseVisualStyleBackColor = True
        '
        'FormTecnicoProductor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(589, 561)
        Me.Controls.Add(Me.ButtonTodosProductores)
        Me.Controls.Add(Me.ButtonTodosTecnicos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBuscarProductor)
        Me.Controls.Add(Me.TextBuscarTecnico)
        Me.Controls.Add(Me.DataGridProductores)
        Me.Controls.Add(Me.DataGridTecnicos)
        Me.Name = "FormTecnicoProductor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Técnico - Productor"
        CType(Me.DataGridTecnicos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridProductores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridTecnicos As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridProductores As System.Windows.Forms.DataGridView
    Friend WithEvents TextBuscarTecnico As System.Windows.Forms.TextBox
    Friend WithEvents TextBuscarProductor As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents IdTecnico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreTecnico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdProductor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreProductor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ButtonTodosTecnicos As System.Windows.Forms.Button
    Friend WithEvents ButtonTodosProductores As System.Windows.Forms.Button
End Class
