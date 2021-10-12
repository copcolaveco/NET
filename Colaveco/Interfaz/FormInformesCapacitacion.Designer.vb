<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInformesCapacitacion
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
        Me.RadioFuncionario = New System.Windows.Forms.RadioButton
        Me.RadioArea = New System.Windows.Forms.RadioButton
        Me.DateDesde = New System.Windows.Forms.DateTimePicker
        Me.DateHasta = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ComboFuncionarios = New System.Windows.Forms.ComboBox
        Me.ComboAreas = New System.Windows.Forms.ComboBox
        Me.RadioTodos = New System.Windows.Forms.RadioButton
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Horas = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ButtonListar = New System.Windows.Forms.Button
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadioFuncionario
        '
        Me.RadioFuncionario.AutoSize = True
        Me.RadioFuncionario.Location = New System.Drawing.Point(32, 108)
        Me.RadioFuncionario.Name = "RadioFuncionario"
        Me.RadioFuncionario.Size = New System.Drawing.Size(96, 17)
        Me.RadioFuncionario.TabIndex = 0
        Me.RadioFuncionario.TabStop = True
        Me.RadioFuncionario.Text = "Por funcionario"
        Me.RadioFuncionario.UseVisualStyleBackColor = True
        '
        'RadioArea
        '
        Me.RadioArea.AutoSize = True
        Me.RadioArea.Location = New System.Drawing.Point(32, 135)
        Me.RadioArea.Name = "RadioArea"
        Me.RadioArea.Size = New System.Drawing.Size(65, 17)
        Me.RadioArea.TabIndex = 1
        Me.RadioArea.TabStop = True
        Me.RadioArea.Text = "Por área"
        Me.RadioArea.UseVisualStyleBackColor = True
        '
        'DateDesde
        '
        Me.DateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDesde.Location = New System.Drawing.Point(32, 36)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(103, 20)
        Me.DateDesde.TabIndex = 2
        '
        'DateHasta
        '
        Me.DateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateHasta.Location = New System.Drawing.Point(141, 36)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(103, 20)
        Me.DateHasta.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Desde"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(138, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Hasta"
        '
        'ComboFuncionarios
        '
        Me.ComboFuncionarios.FormattingEnabled = True
        Me.ComboFuncionarios.Location = New System.Drawing.Point(134, 104)
        Me.ComboFuncionarios.Name = "ComboFuncionarios"
        Me.ComboFuncionarios.Size = New System.Drawing.Size(173, 21)
        Me.ComboFuncionarios.TabIndex = 6
        '
        'ComboAreas
        '
        Me.ComboAreas.FormattingEnabled = True
        Me.ComboAreas.Location = New System.Drawing.Point(134, 131)
        Me.ComboAreas.Name = "ComboAreas"
        Me.ComboAreas.Size = New System.Drawing.Size(173, 21)
        Me.ComboAreas.TabIndex = 7
        '
        'RadioTodos
        '
        Me.RadioTodos.AutoSize = True
        Me.RadioTodos.Location = New System.Drawing.Point(32, 76)
        Me.RadioTodos.Name = "RadioTodos"
        Me.RadioTodos.Size = New System.Drawing.Size(55, 17)
        Me.RadioTodos.TabIndex = 8
        Me.RadioTodos.TabStop = True
        Me.RadioTodos.Text = "Todos"
        Me.RadioTodos.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Tipo, Me.Horas})
        Me.DataGridView1.Location = New System.Drawing.Point(32, 169)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(275, 320)
        Me.DataGridView1.TabIndex = 9
        '
        'Tipo
        '
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.Width = 150
        '
        'Horas
        '
        Me.Horas.HeaderText = "Horas"
        Me.Horas.Name = "Horas"
        '
        'ButtonListar
        '
        Me.ButtonListar.Location = New System.Drawing.Point(258, 33)
        Me.ButtonListar.Name = "ButtonListar"
        Me.ButtonListar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonListar.TabIndex = 10
        Me.ButtonListar.Text = "Listar"
        Me.ButtonListar.UseVisualStyleBackColor = True
        '
        'FormInformesCapacitacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(343, 501)
        Me.Controls.Add(Me.ButtonListar)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.RadioTodos)
        Me.Controls.Add(Me.ComboAreas)
        Me.Controls.Add(Me.ComboFuncionarios)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateHasta)
        Me.Controls.Add(Me.DateDesde)
        Me.Controls.Add(Me.RadioArea)
        Me.Controls.Add(Me.RadioFuncionario)
        Me.Name = "FormInformesCapacitacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informes de capacitación"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RadioFuncionario As System.Windows.Forms.RadioButton
    Friend WithEvents RadioArea As System.Windows.Forms.RadioButton
    Friend WithEvents DateDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboFuncionarios As System.Windows.Forms.ComboBox
    Friend WithEvents ComboAreas As System.Windows.Forms.ComboBox
    Friend WithEvents RadioTodos As System.Windows.Forms.RadioButton
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonListar As System.Windows.Forms.Button
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Horas As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
