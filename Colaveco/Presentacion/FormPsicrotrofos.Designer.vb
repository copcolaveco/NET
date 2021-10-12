<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPsicrotrofos
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
        Me.ButtonEliminar = New System.Windows.Forms.Button
        Me.ButtonGuardar = New System.Windows.Forms.Button
        Me.ButtonNuevo = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DateFecha = New System.Windows.Forms.DateTimePicker
        Me.TextPromedio = New System.Windows.Forms.TextBox
        Me.TextMuestra = New System.Windows.Forms.TextBox
        Me.TextFicha = New System.Windows.Forms.TextBox
        Me.TextId = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.NumericPaginado = New System.Windows.Forms.NumericUpDown
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Ficha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Muestra = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.valor1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.valor2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Promedio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TextValor1 = New System.Windows.Forms.TextBox
        Me.TextValor2 = New System.Windows.Forms.TextBox
        CType(Me.NumericPaginado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(178, 117)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEliminar.TabIndex = 9
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(97, 117)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 7
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(16, 117)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNuevo.TabIndex = 8
        Me.ButtonNuevo.Text = "Nuevo"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(261, 59)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 13)
        Me.Label9.TabIndex = 40
        Me.Label9.Text = "Promedio"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(220, 59)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(16, 13)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "-4"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(156, 59)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(16, 13)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "-3"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(48, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Muestra"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(220, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Ficha"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(96, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Fecha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Id"
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(81, 31)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(100, 20)
        Me.DateFecha.TabIndex = 101
        '
        'TextPromedio
        '
        Me.TextPromedio.Location = New System.Drawing.Point(264, 76)
        Me.TextPromedio.Name = "TextPromedio"
        Me.TextPromedio.ReadOnly = True
        Me.TextPromedio.Size = New System.Drawing.Size(59, 20)
        Me.TextPromedio.TabIndex = 6
        Me.TextPromedio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextMuestra
        '
        Me.TextMuestra.Location = New System.Drawing.Point(16, 75)
        Me.TextMuestra.Name = "TextMuestra"
        Me.TextMuestra.Size = New System.Drawing.Size(112, 20)
        Me.TextMuestra.TabIndex = 3
        '
        'TextFicha
        '
        Me.TextFicha.Location = New System.Drawing.Point(187, 31)
        Me.TextFicha.Name = "TextFicha"
        Me.TextFicha.Size = New System.Drawing.Size(100, 20)
        Me.TextFicha.TabIndex = 0
        Me.TextFicha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(16, 31)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(59, 20)
        Me.TextId.TabIndex = 100
        Me.TextId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 162)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Mostrar últimos"
        '
        'NumericPaginado
        '
        Me.NumericPaginado.Increment = New Decimal(New Integer() {50, 0, 0, 0})
        Me.NumericPaginado.Location = New System.Drawing.Point(99, 160)
        Me.NumericPaginado.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.NumericPaginado.Minimum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.NumericPaginado.Name = "NumericPaginado"
        Me.NumericPaginado.Size = New System.Drawing.Size(70, 20)
        Me.NumericPaginado.TabIndex = 10
        Me.NumericPaginado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericPaginado.Value = New Decimal(New Integer() {50, 0, 0, 0})
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Fecha, Me.Ficha, Me.Muestra, Me.valor1, Me.valor2, Me.Promedio})
        Me.DataGridView1.Location = New System.Drawing.Point(16, 194)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(477, 374)
        Me.DataGridView1.TabIndex = 11
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
        Me.valor1.HeaderText = "-3"
        Me.valor1.Name = "valor1"
        Me.valor1.Width = 40
        '
        'valor2
        '
        Me.valor2.HeaderText = "-4"
        Me.valor2.Name = "valor2"
        Me.valor2.Width = 40
        '
        'Promedio
        '
        Me.Promedio.HeaderText = "Promedio"
        Me.Promedio.Name = "Promedio"
        Me.Promedio.Width = 60
        '
        'TextValor1
        '
        Me.TextValor1.Location = New System.Drawing.Point(134, 75)
        Me.TextValor1.Name = "TextValor1"
        Me.TextValor1.Size = New System.Drawing.Size(59, 20)
        Me.TextValor1.TabIndex = 4
        Me.TextValor1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextValor2
        '
        Me.TextValor2.Location = New System.Drawing.Point(199, 75)
        Me.TextValor2.Name = "TextValor2"
        Me.TextValor2.Size = New System.Drawing.Size(59, 20)
        Me.TextValor2.TabIndex = 5
        Me.TextValor2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FormPsicrotrofos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(508, 582)
        Me.Controls.Add(Me.TextValor2)
        Me.Controls.Add(Me.TextValor1)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.TextPromedio)
        Me.Controls.Add(Me.TextMuestra)
        Me.Controls.Add(Me.TextFicha)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NumericPaginado)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FormPsicrotrofos"
        Me.Text = "Psicrótrofos"
        CType(Me.NumericPaginado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextPromedio As System.Windows.Forms.TextBox
    Friend WithEvents TextMuestra As System.Windows.Forms.TextBox
    Friend WithEvents TextFicha As System.Windows.Forms.TextBox
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumericPaginado As System.Windows.Forms.NumericUpDown
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents TextValor1 As System.Windows.Forms.TextBox
    Friend WithEvents TextValor2 As System.Windows.Forms.TextBox
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ficha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Muestra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valor1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valor2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Promedio As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
