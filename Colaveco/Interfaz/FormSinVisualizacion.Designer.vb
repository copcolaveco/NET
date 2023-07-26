<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSinVisualizacion
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ficha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Muestras = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Abonado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Visualizacion = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Fecha2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Abonado2 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Visualizacion2 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.DateFecha = New System.Windows.Forms.DateTimePicker()
        Me.ButtonImprimir = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Id2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ficha2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Muestras2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Abonado3 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Visualizacion3 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Fecha4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observaciones2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SinVisualizacion = New System.Windows.Forms.DataGridViewButtonColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Ficha, Me.Fecha, Me.Cliente, Me.Tipo, Me.Muestras, Me.Importe, Me.Abonado, Me.Visualizacion, Me.Fecha2, Me.Observaciones, Me.Abonado2, Me.Visualizacion2})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.Location = New System.Drawing.Point(8, 7)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(1485, 628)
        Me.DataGridView1.TabIndex = 0
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'Ficha
        '
        Me.Ficha.HeaderText = "Ficha"
        Me.Ficha.Name = "Ficha"
        Me.Ficha.Width = 60
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 80
        '
        'Cliente
        '
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.Width = 150
        '
        'Tipo
        '
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.Width = 150
        '
        'Muestras
        '
        Me.Muestras.HeaderText = "Muestras"
        Me.Muestras.Name = "Muestras"
        Me.Muestras.Width = 60
        '
        'Importe
        '
        Me.Importe.HeaderText = "Importe $"
        Me.Importe.Name = "Importe"
        Me.Importe.Width = 60
        '
        'Abonado
        '
        Me.Abonado.HeaderText = "Abonado"
        Me.Abonado.Name = "Abonado"
        Me.Abonado.Visible = False
        Me.Abonado.Width = 80
        '
        'Visualizacion
        '
        Me.Visualizacion.HeaderText = "Visualización"
        Me.Visualizacion.Name = "Visualizacion"
        Me.Visualizacion.Visible = False
        Me.Visualizacion.Width = 80
        '
        'Fecha2
        '
        Me.Fecha2.HeaderText = "Fecha V."
        Me.Fecha2.Name = "Fecha2"
        Me.Fecha2.Width = 80
        '
        'Observaciones
        '
        Me.Observaciones.HeaderText = "Observaciones"
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.Width = 250
        '
        'Abonado2
        '
        Me.Abonado2.HeaderText = ""
        Me.Abonado2.Name = "Abonado2"
        Me.Abonado2.Text = "Abonado"
        Me.Abonado2.UseColumnTextForButtonValue = True
        '
        'Visualizacion2
        '
        Me.Visualizacion2.HeaderText = ""
        Me.Visualizacion2.Name = "Visualizacion2"
        Me.Visualizacion2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Visualizacion2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Visualizacion2.Text = "Visible"
        Me.Visualizacion2.UseColumnTextForButtonValue = True
        '
        'DateFecha
        '
        Me.DateFecha.Enabled = False
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(1235, 17)
        Me.DateFecha.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(129, 22)
        Me.DateFecha.TabIndex = 4
        '
        'ButtonImprimir
        '
        Me.ButtonImprimir.Location = New System.Drawing.Point(611, 17)
        Me.ButtonImprimir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonImprimir.Name = "ButtonImprimir"
        Me.ButtonImprimir.Size = New System.Drawing.Size(220, 28)
        Me.ButtonImprimir.TabIndex = 5
        Me.ButtonImprimir.Text = "Imprimir"
        Me.ButtonImprimir.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(16, 47)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1512, 674)
        Me.TabControl1.TabIndex = 6
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage1.Size = New System.Drawing.Size(1504, 645)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Sin visualización"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.DataGridView2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage2.Size = New System.Drawing.Size(1504, 645)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Con visualización"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id2, Me.Ficha2, Me.Fecha3, Me.Cliente2, Me.Tipo2, Me.Muestras2, Me.Importe2, Me.Abonado3, Me.Visualizacion3, Me.Fecha4, Me.Observaciones2, Me.SinVisualizacion})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView2.Location = New System.Drawing.Point(8, 7)
        Me.DataGridView2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.Size = New System.Drawing.Size(1352, 628)
        Me.DataGridView2.TabIndex = 1
        '
        'Id2
        '
        Me.Id2.HeaderText = "Id"
        Me.Id2.Name = "Id2"
        Me.Id2.Visible = False
        '
        'Ficha2
        '
        Me.Ficha2.HeaderText = "Ficha"
        Me.Ficha2.Name = "Ficha2"
        Me.Ficha2.Width = 60
        '
        'Fecha3
        '
        Me.Fecha3.HeaderText = "Fecha"
        Me.Fecha3.Name = "Fecha3"
        Me.Fecha3.Width = 80
        '
        'Cliente2
        '
        Me.Cliente2.HeaderText = "Cliente"
        Me.Cliente2.Name = "Cliente2"
        Me.Cliente2.Width = 150
        '
        'Tipo2
        '
        Me.Tipo2.HeaderText = "Tipo"
        Me.Tipo2.Name = "Tipo2"
        Me.Tipo2.Width = 150
        '
        'Muestras2
        '
        Me.Muestras2.HeaderText = "Muestras"
        Me.Muestras2.Name = "Muestras2"
        Me.Muestras2.Width = 60
        '
        'Importe2
        '
        Me.Importe2.HeaderText = "Importe $"
        Me.Importe2.Name = "Importe2"
        Me.Importe2.Width = 60
        '
        'Abonado3
        '
        Me.Abonado3.HeaderText = "Abonado"
        Me.Abonado3.Name = "Abonado3"
        Me.Abonado3.Visible = False
        Me.Abonado3.Width = 80
        '
        'Visualizacion3
        '
        Me.Visualizacion3.HeaderText = "Visualización"
        Me.Visualizacion3.Name = "Visualizacion3"
        Me.Visualizacion3.Visible = False
        Me.Visualizacion3.Width = 80
        '
        'Fecha4
        '
        Me.Fecha4.HeaderText = "Fecha V."
        Me.Fecha4.Name = "Fecha4"
        Me.Fecha4.Width = 80
        '
        'Observaciones2
        '
        Me.Observaciones2.HeaderText = "Observaciones"
        Me.Observaciones2.Name = "Observaciones2"
        Me.Observaciones2.Width = 250
        '
        'SinVisualizacion
        '
        Me.SinVisualizacion.HeaderText = ""
        Me.SinVisualizacion.Name = "SinVisualizacion"
        Me.SinVisualizacion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SinVisualizacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.SinVisualizacion.Text = "Sin visualización"
        Me.SinVisualizacion.UseColumnTextForButtonValue = True
        '
        'FormSinVisualizacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1544, 741)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ButtonImprimir)
        Me.Controls.Add(Me.DateFecha)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FormSinVisualizacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informes sin visualización"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents ButtonImprimir As System.Windows.Forms.Button
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ficha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Muestras As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Abonado As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Visualizacion As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Fecha2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Abonado2 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Visualizacion2 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Id2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ficha2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Muestras2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Importe2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Abonado3 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Visualizacion3 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Fecha4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observaciones2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SinVisualizacion As System.Windows.Forms.DataGridViewButtonColumn
End Class
