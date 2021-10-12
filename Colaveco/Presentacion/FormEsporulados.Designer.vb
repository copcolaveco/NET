<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEsporulados
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.NumericPaginado = New System.Windows.Forms.NumericUpDown
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextId = New System.Windows.Forms.TextBox
        Me.TextFicha = New System.Windows.Forms.TextBox
        Me.TextMuestra = New System.Windows.Forms.TextBox
        Me.TextResultado = New System.Windows.Forms.TextBox
        Me.DateFecha = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.ButtonNuevo = New System.Windows.Forms.Button
        Me.ButtonGuardar = New System.Windows.Forms.Button
        Me.ButtonEliminar = New System.Windows.Forms.Button
        Me.Numeric1 = New System.Windows.Forms.NumericUpDown
        Me.Numeric2 = New System.Windows.Forms.NumericUpDown
        Me.Numeric3 = New System.Windows.Forms.NumericUpDown
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Ficha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Muestra = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.valor1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.valor2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.valor3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Resultado = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericPaginado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Numeric1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Numeric2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Numeric3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Fecha, Me.Ficha, Me.Muestra, Me.valor1, Me.valor2, Me.valor3, Me.Resultado})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 196)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(495, 374)
        Me.DataGridView1.TabIndex = 12
        '
        'NumericPaginado
        '
        Me.NumericPaginado.Increment = New Decimal(New Integer() {50, 0, 0, 0})
        Me.NumericPaginado.Location = New System.Drawing.Point(95, 162)
        Me.NumericPaginado.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.NumericPaginado.Minimum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.NumericPaginado.Name = "NumericPaginado"
        Me.NumericPaginado.Size = New System.Drawing.Size(70, 20)
        Me.NumericPaginado.TabIndex = 11
        Me.NumericPaginado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericPaginado.Value = New Decimal(New Integer() {50, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 164)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Mostrar últimos"
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(12, 33)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(59, 20)
        Me.TextId.TabIndex = 200
        '
        'TextFicha
        '
        Me.TextFicha.Location = New System.Drawing.Point(183, 33)
        Me.TextFicha.Name = "TextFicha"
        Me.TextFicha.Size = New System.Drawing.Size(82, 20)
        Me.TextFicha.TabIndex = 0
        Me.TextFicha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextMuestra
        '
        Me.TextMuestra.Location = New System.Drawing.Point(12, 77)
        Me.TextMuestra.Name = "TextMuestra"
        Me.TextMuestra.Size = New System.Drawing.Size(112, 20)
        Me.TextMuestra.TabIndex = 3
        '
        'TextResultado
        '
        Me.TextResultado.Location = New System.Drawing.Point(325, 77)
        Me.TextResultado.Name = "TextResultado"
        Me.TextResultado.ReadOnly = True
        Me.TextResultado.Size = New System.Drawing.Size(59, 20)
        Me.TextResultado.TabIndex = 7
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(77, 33)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(100, 20)
        Me.DateFecha.TabIndex = 201
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Id"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(92, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Fecha"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(199, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Ficha"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(44, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Muestra"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(152, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(13, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(216, 61)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(16, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "-1"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(278, 61)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(16, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "-2"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(322, 61)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Resultado"
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(12, 119)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNuevo.TabIndex = 9
        Me.ButtonNuevo.Text = "Nuevo"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(93, 119)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 8
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(174, 119)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEliminar.TabIndex = 10
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'Numeric1
        '
        Me.Numeric1.Location = New System.Drawing.Point(130, 77)
        Me.Numeric1.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.Numeric1.Name = "Numeric1"
        Me.Numeric1.Size = New System.Drawing.Size(59, 20)
        Me.Numeric1.TabIndex = 4
        Me.Numeric1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Numeric2
        '
        Me.Numeric2.Location = New System.Drawing.Point(195, 78)
        Me.Numeric2.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.Numeric2.Name = "Numeric2"
        Me.Numeric2.Size = New System.Drawing.Size(59, 20)
        Me.Numeric2.TabIndex = 5
        Me.Numeric2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Numeric3
        '
        Me.Numeric3.Location = New System.Drawing.Point(260, 78)
        Me.Numeric3.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.Numeric3.Name = "Numeric3"
        Me.Numeric3.Size = New System.Drawing.Size(59, 20)
        Me.Numeric3.TabIndex = 6
        Me.Numeric3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        Me.Id.Width = 50
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 70
        '
        'Ficha
        '
        Me.Ficha.HeaderText = "Ficha"
        Me.Ficha.Name = "Ficha"
        Me.Ficha.Width = 50
        '
        'Muestra
        '
        Me.Muestra.HeaderText = "Muestra"
        Me.Muestra.Name = "Muestra"
        '
        'valor1
        '
        Me.valor1.HeaderText = "0"
        Me.valor1.Name = "valor1"
        Me.valor1.Width = 30
        '
        'valor2
        '
        Me.valor2.HeaderText = "-1"
        Me.valor2.Name = "valor2"
        Me.valor2.Width = 30
        '
        'valor3
        '
        Me.valor3.HeaderText = "-2"
        Me.valor3.Name = "valor3"
        Me.valor3.Width = 30
        '
        'Resultado
        '
        Me.Resultado.HeaderText = "Resultado"
        Me.Resultado.Name = "Resultado"
        Me.Resultado.Width = 60
        '
        'FormEsporulados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(521, 582)
        Me.Controls.Add(Me.Numeric3)
        Me.Controls.Add(Me.Numeric2)
        Me.Controls.Add(Me.Numeric1)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.TextResultado)
        Me.Controls.Add(Me.TextMuestra)
        Me.Controls.Add(Me.TextFicha)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NumericPaginado)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FormEsporulados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Esporulados"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericPaginado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Numeric1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Numeric2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Numeric3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents NumericPaginado As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents TextFicha As System.Windows.Forms.TextBox
    Friend WithEvents TextMuestra As System.Windows.Forms.TextBox
    Friend WithEvents TextResultado As System.Windows.Forms.TextBox
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents Numeric1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Numeric2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Numeric3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ficha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Muestra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valor1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valor2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valor3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Resultado As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
