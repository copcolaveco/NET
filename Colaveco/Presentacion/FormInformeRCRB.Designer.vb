<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInformeRCRB
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
        Me.ButtonEmpresa = New System.Windows.Forms.Button
        Me.TextEmpresa = New System.Windows.Forms.TextBox
        Me.DateDesde = New System.Windows.Forms.DateTimePicker
        Me.DateHasta = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.ButtonListar = New System.Windows.Forms.Button
        Me.Ficha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Matricula = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RB = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TextIdEmpresa = New System.Windows.Forms.TextBox
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.ButtonExcel = New System.Windows.Forms.Button
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonEmpresa
        '
        Me.ButtonEmpresa.Location = New System.Drawing.Point(15, 55)
        Me.ButtonEmpresa.Name = "ButtonEmpresa"
        Me.ButtonEmpresa.Size = New System.Drawing.Size(126, 23)
        Me.ButtonEmpresa.TabIndex = 0
        Me.ButtonEmpresa.Text = "Seleccionar empresa"
        Me.ButtonEmpresa.UseVisualStyleBackColor = True
        '
        'TextEmpresa
        '
        Me.TextEmpresa.Location = New System.Drawing.Point(218, 58)
        Me.TextEmpresa.Name = "TextEmpresa"
        Me.TextEmpresa.ReadOnly = True
        Me.TextEmpresa.Size = New System.Drawing.Size(270, 20)
        Me.TextEmpresa.TabIndex = 1
        '
        'DateDesde
        '
        Me.DateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDesde.Location = New System.Drawing.Point(15, 29)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(108, 20)
        Me.DateDesde.TabIndex = 2
        '
        'DateHasta
        '
        Me.DateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateHasta.Location = New System.Drawing.Point(129, 29)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(108, 20)
        Me.DateHasta.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Desde"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(126, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Hasta"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ficha, Me.Fecha, Me.Matricula, Me.RC, Me.RB})
        Me.DataGridView1.Location = New System.Drawing.Point(15, 113)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(584, 454)
        Me.DataGridView1.TabIndex = 6
        '
        'ButtonListar
        '
        Me.ButtonListar.Location = New System.Drawing.Point(494, 56)
        Me.ButtonListar.Name = "ButtonListar"
        Me.ButtonListar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonListar.TabIndex = 7
        Me.ButtonListar.Text = "Listar"
        Me.ButtonListar.UseVisualStyleBackColor = True
        '
        'Ficha
        '
        Me.Ficha.HeaderText = "Ficha"
        Me.Ficha.Name = "Ficha"
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        '
        'Matricula
        '
        Me.Matricula.HeaderText = "Matrícula"
        Me.Matricula.Name = "Matricula"
        '
        'RC
        '
        Me.RC.HeaderText = "RC"
        Me.RC.Name = "RC"
        '
        'RB
        '
        Me.RB.HeaderText = "RB"
        Me.RB.Name = "RB"
        '
        'TextIdEmpresa
        '
        Me.TextIdEmpresa.Location = New System.Drawing.Point(147, 57)
        Me.TextIdEmpresa.Name = "TextIdEmpresa"
        Me.TextIdEmpresa.ReadOnly = True
        Me.TextIdEmpresa.Size = New System.Drawing.Size(65, 20)
        Me.TextIdEmpresa.TabIndex = 8
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(15, 84)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(584, 23)
        Me.ProgressBar1.TabIndex = 9
        '
        'ButtonExcel
        '
        Me.ButtonExcel.Location = New System.Drawing.Point(575, 57)
        Me.ButtonExcel.Name = "ButtonExcel"
        Me.ButtonExcel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonExcel.TabIndex = 10
        Me.ButtonExcel.Text = "Excel"
        Me.ButtonExcel.UseVisualStyleBackColor = True
        '
        'FormInformeRCRB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(677, 579)
        Me.Controls.Add(Me.ButtonExcel)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.TextIdEmpresa)
        Me.Controls.Add(Me.ButtonListar)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateHasta)
        Me.Controls.Add(Me.DateDesde)
        Me.Controls.Add(Me.TextEmpresa)
        Me.Controls.Add(Me.ButtonEmpresa)
        Me.Name = "FormInformeRCRB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de RC y RB por empresa"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonEmpresa As System.Windows.Forms.Button
    Friend WithEvents TextEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents DateDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Ficha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Matricula As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ButtonListar As System.Windows.Forms.Button
    Friend WithEvents TextIdEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents ButtonExcel As System.Windows.Forms.Button
End Class
