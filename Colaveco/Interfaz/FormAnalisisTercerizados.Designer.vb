<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAnalisisTercerizados
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
        Me.Label12 = New System.Windows.Forms.Label()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Id2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Muestra2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Analisis2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quitar2 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.ButtonAgregar = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextMuestras = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Analisis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.X = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DateFechaIngreso = New System.Windows.Forms.DateTimePicker()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(532, 37)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 13)
        Me.Label12.TabIndex = 138
        Me.Label12.Text = "Listado"
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id2, Me.Muestra2, Me.Analisis2, Me.Quitar2})
        Me.DataGridView2.Location = New System.Drawing.Point(455, 56)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.Size = New System.Drawing.Size(479, 440)
        Me.DataGridView2.TabIndex = 137
        '
        'Id2
        '
        Me.Id2.HeaderText = "Id"
        Me.Id2.Name = "Id2"
        Me.Id2.Visible = False
        '
        'Muestra2
        '
        Me.Muestra2.HeaderText = "Muestra"
        Me.Muestra2.Name = "Muestra2"
        '
        'Analisis2
        '
        Me.Analisis2.HeaderText = "Análisis"
        Me.Analisis2.Name = "Analisis2"
        Me.Analisis2.Width = 300
        '
        'Quitar2
        '
        Me.Quitar2.HeaderText = ""
        Me.Quitar2.Name = "Quitar2"
        Me.Quitar2.Text = "Quitar"
        Me.Quitar2.UseColumnTextForButtonValue = True
        Me.Quitar2.Width = 60
        '
        'ButtonAgregar
        '
        Me.ButtonAgregar.Location = New System.Drawing.Point(374, 56)
        Me.ButtonAgregar.Name = "ButtonAgregar"
        Me.ButtonAgregar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonAgregar.TabIndex = 136
        Me.ButtonAgregar.Text = "Agregar >>>"
        Me.ButtonAgregar.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(225, 37)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 135
        Me.Label8.Text = "Análisis"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 134
        Me.Label5.Text = "Muestra"
        '
        'TextMuestras
        '
        Me.TextMuestras.Location = New System.Drawing.Point(12, 30)
        Me.TextMuestras.Name = "TextMuestras"
        Me.TextMuestras.Size = New System.Drawing.Size(171, 20)
        Me.TextMuestras.TabIndex = 133
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Analisis, Me.X})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 56)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(356, 440)
        Me.DataGridView1.TabIndex = 132
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'Analisis
        '
        Me.Analisis.HeaderText = "Análisis"
        Me.Analisis.Name = "Analisis"
        Me.Analisis.Width = 300
        '
        'X
        '
        Me.X.HeaderText = "X"
        Me.X.Name = "X"
        Me.X.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.X.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.X.Width = 40
        '
        'DateFechaIngreso
        '
        Me.DateFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFechaIngreso.Location = New System.Drawing.Point(820, 27)
        Me.DateFechaIngreso.Name = "DateFechaIngreso"
        Me.DateFechaIngreso.Size = New System.Drawing.Size(114, 20)
        Me.DateFechaIngreso.TabIndex = 140
        '
        'FormAnalisisTercerizados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(947, 536)
        Me.Controls.Add(Me.DateFechaIngreso)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.ButtonAgregar)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextMuestras)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FormAnalisisTercerizados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Analisis Tercerizados"
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Id2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Muestra2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Analisis2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quitar2 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents ButtonAgregar As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextMuestras As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Analisis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents X As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DateFechaIngreso As System.Windows.Forms.DateTimePicker
End Class
