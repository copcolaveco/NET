<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormControldeInformesPre
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
        Me.ButtonListar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateHasta = New System.Windows.Forms.DateTimePicker()
        Me.DateDesde = New System.Windows.Forms.DateTimePicker()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.FqCal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FqCl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MicroCal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MicroA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MicroSp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nutricion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Suelos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextTotal = New System.Windows.Forms.TextBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.RadioFQ = New System.Windows.Forms.RadioButton()
        Me.RadioMicro = New System.Windows.Forms.RadioButton()
        Me.RadioSuelos = New System.Windows.Forms.RadioButton()
        Me.RadioNutricion = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonListar
        '
        Me.ButtonListar.Location = New System.Drawing.Point(305, 33)
        Me.ButtonListar.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonListar.Name = "ButtonListar"
        Me.ButtonListar.Size = New System.Drawing.Size(100, 28)
        Me.ButtonListar.TabIndex = 15
        Me.ButtonListar.Text = "Listar"
        Me.ButtonListar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(164, 17)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 17)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Hasta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 17)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 17)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Desde"
        '
        'DateHasta
        '
        Me.DateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateHasta.Location = New System.Drawing.Point(168, 37)
        Me.DateHasta.Margin = New System.Windows.Forms.Padding(4)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(128, 22)
        Me.DateHasta.TabIndex = 9
        '
        'DateDesde
        '
        Me.DateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDesde.Location = New System.Drawing.Point(31, 37)
        Me.DateDesde.Margin = New System.Windows.Forms.Padding(4)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(128, 22)
        Me.DateDesde.TabIndex = 8
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FqCal, Me.FqCl, Me.MicroCal, Me.MicroA, Me.MicroSp, Me.Nutricion, Me.Suelos})
        Me.DataGridView1.Location = New System.Drawing.Point(31, 85)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(596, 74)
        Me.DataGridView1.TabIndex = 16
        '
        'FqCal
        '
        Me.FqCal.HeaderText = "FQ CAL"
        Me.FqCal.Name = "FqCal"
        Me.FqCal.Width = 60
        '
        'FqCl
        '
        Me.FqCl.HeaderText = "FQ CL"
        Me.FqCl.Name = "FqCl"
        Me.FqCl.Width = 60
        '
        'MicroCal
        '
        Me.MicroCal.HeaderText = "MICRO CAL"
        Me.MicroCal.Name = "MicroCal"
        Me.MicroCal.Width = 60
        '
        'MicroA
        '
        Me.MicroA.HeaderText = "MICRO AGUA"
        Me.MicroA.Name = "MicroA"
        Me.MicroA.Width = 60
        '
        'MicroSp
        '
        Me.MicroSp.HeaderText = "MICRO SP"
        Me.MicroSp.Name = "MicroSp"
        Me.MicroSp.Width = 60
        '
        'Nutricion
        '
        Me.Nutricion.HeaderText = "NUT"
        Me.Nutricion.Name = "Nutricion"
        Me.Nutricion.Width = 60
        '
        'Suelos
        '
        Me.Suelos.HeaderText = "SUE"
        Me.Suelos.Name = "Suelos"
        Me.Suelos.Width = 60
        '
        'TextTotal
        '
        Me.TextTotal.Location = New System.Drawing.Point(635, 85)
        Me.TextTotal.Margin = New System.Windows.Forms.Padding(4)
        Me.TextTotal.Name = "TextTotal"
        Me.TextTotal.ReadOnly = True
        Me.TextTotal.Size = New System.Drawing.Size(132, 22)
        Me.TextTotal.TabIndex = 17
        Me.TextTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(31, 188)
        Me.DataGridView2.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(1604, 578)
        Me.DataGridView2.TabIndex = 18
        '
        'RadioFQ
        '
        Me.RadioFQ.AutoSize = True
        Me.RadioFQ.Location = New System.Drawing.Point(635, 148)
        Me.RadioFQ.Margin = New System.Windows.Forms.Padding(4)
        Me.RadioFQ.Name = "RadioFQ"
        Me.RadioFQ.Size = New System.Drawing.Size(121, 21)
        Me.RadioFQ.TabIndex = 19
        Me.RadioFQ.TabStop = True
        Me.RadioFQ.Text = "Físico-Químico"
        Me.RadioFQ.UseVisualStyleBackColor = True
        '
        'RadioMicro
        '
        Me.RadioMicro.AutoSize = True
        Me.RadioMicro.Location = New System.Drawing.Point(772, 148)
        Me.RadioMicro.Margin = New System.Windows.Forms.Padding(4)
        Me.RadioMicro.Name = "RadioMicro"
        Me.RadioMicro.Size = New System.Drawing.Size(112, 21)
        Me.RadioMicro.TabIndex = 20
        Me.RadioMicro.TabStop = True
        Me.RadioMicro.Text = "Microbiología"
        Me.RadioMicro.UseVisualStyleBackColor = True
        '
        'RadioSuelos
        '
        Me.RadioSuelos.AutoSize = True
        Me.RadioSuelos.Location = New System.Drawing.Point(899, 148)
        Me.RadioSuelos.Margin = New System.Windows.Forms.Padding(4)
        Me.RadioSuelos.Name = "RadioSuelos"
        Me.RadioSuelos.Size = New System.Drawing.Size(72, 21)
        Me.RadioSuelos.TabIndex = 21
        Me.RadioSuelos.TabStop = True
        Me.RadioSuelos.Text = "Suelos"
        Me.RadioSuelos.UseVisualStyleBackColor = True
        '
        'RadioNutricion
        '
        Me.RadioNutricion.AutoSize = True
        Me.RadioNutricion.Location = New System.Drawing.Point(983, 148)
        Me.RadioNutricion.Margin = New System.Windows.Forms.Padding(4)
        Me.RadioNutricion.Name = "RadioNutricion"
        Me.RadioNutricion.Size = New System.Drawing.Size(85, 21)
        Me.RadioNutricion.TabIndex = 22
        Me.RadioNutricion.TabStop = True
        Me.RadioNutricion.Text = "Nutrición"
        Me.RadioNutricion.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(681, 65)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 17)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Total"
        '
        'FormControldeInformesPre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1651, 784)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.RadioNutricion)
        Me.Controls.Add(Me.RadioSuelos)
        Me.Controls.Add(Me.RadioMicro)
        Me.Controls.Add(Me.RadioFQ)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.TextTotal)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ButtonListar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateHasta)
        Me.Controls.Add(Me.DateDesde)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormControldeInformesPre"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control de Informes (antes de subir)"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonListar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents TextTotal As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents RadioFQ As System.Windows.Forms.RadioButton
    Friend WithEvents RadioMicro As System.Windows.Forms.RadioButton
    Friend WithEvents RadioSuelos As System.Windows.Forms.RadioButton
    Friend WithEvents RadioNutricion As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents FqCal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FqCl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MicroCal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MicroA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MicroSp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nutricion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Suelos As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
