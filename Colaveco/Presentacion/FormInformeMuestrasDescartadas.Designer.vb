<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInformeMuestrasDescartadas
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DateDesde = New System.Windows.Forms.DateTimePicker
        Me.DateHasta = New System.Windows.Forms.DateTimePicker
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ButtonListar = New System.Windows.Forms.Button
        Me.ButtonExportar = New System.Windows.Forms.Button
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Ficha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Productor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Muestra = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TipoInforme = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MotivoDescarte = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Valor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InfRetorno = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Autorizacion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DateDesde
        '
        Me.DateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDesde.Location = New System.Drawing.Point(12, 40)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(109, 20)
        Me.DateDesde.TabIndex = 0
        '
        'DateHasta
        '
        Me.DateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateHasta.Location = New System.Drawing.Point(127, 40)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(109, 20)
        Me.DateHasta.TabIndex = 1
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Fecha, Me.Ficha, Me.Productor, Me.Muestra, Me.Cantidad, Me.TipoInforme, Me.MotivoDescarte, Me.Valor, Me.InfRetorno, Me.Autorizacion, Me.Observaciones})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Location = New System.Drawing.Point(12, 80)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(818, 454)
        Me.DataGridView1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Desde"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(124, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Hasta"
        '
        'ButtonListar
        '
        Me.ButtonListar.Location = New System.Drawing.Point(251, 37)
        Me.ButtonListar.Name = "ButtonListar"
        Me.ButtonListar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonListar.TabIndex = 5
        Me.ButtonListar.Text = "Listar"
        Me.ButtonListar.UseVisualStyleBackColor = True
        '
        'ButtonExportar
        '
        Me.ButtonExportar.Location = New System.Drawing.Point(332, 37)
        Me.ButtonExportar.Name = "ButtonExportar"
        Me.ButtonExportar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonExportar.TabIndex = 6
        Me.ButtonExportar.Text = "Exportar"
        Me.ButtonExportar.UseVisualStyleBackColor = True
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 80
        '
        'Ficha
        '
        Me.Ficha.HeaderText = "Ficha"
        Me.Ficha.Name = "Ficha"
        Me.Ficha.Width = 50
        '
        'Productor
        '
        Me.Productor.HeaderText = "Productor"
        Me.Productor.Name = "Productor"
        Me.Productor.Width = 200
        '
        'Muestra
        '
        Me.Muestra.HeaderText = "Muestra"
        Me.Muestra.Name = "Muestra"
        Me.Muestra.Width = 50
        '
        'Cantidad
        '
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Width = 50
        '
        'TipoInforme
        '
        Me.TipoInforme.HeaderText = "Tipo de informe"
        Me.TipoInforme.Name = "TipoInforme"
        '
        'MotivoDescarte
        '
        Me.MotivoDescarte.HeaderText = "Motivo de descarte"
        Me.MotivoDescarte.Name = "MotivoDescarte"
        Me.MotivoDescarte.Width = 150
        '
        'Valor
        '
        Me.Valor.HeaderText = "Valor"
        Me.Valor.Name = "Valor"
        Me.Valor.Width = 40
        '
        'InfRetorno
        '
        Me.InfRetorno.HeaderText = "Información de retorno"
        Me.InfRetorno.Name = "InfRetorno"
        Me.InfRetorno.Width = 60
        '
        'Autorizacion
        '
        Me.Autorizacion.HeaderText = "Autorización"
        Me.Autorizacion.Name = "Autorizacion"
        '
        'Observaciones
        '
        Me.Observaciones.HeaderText = "Observaciones"
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.Width = 200
        '
        'FormInformeMuestrasDescartadas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(842, 546)
        Me.Controls.Add(Me.ButtonExportar)
        Me.Controls.Add(Me.ButtonListar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.DateHasta)
        Me.Controls.Add(Me.DateDesde)
        Me.Name = "FormInformeMuestrasDescartadas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de muestras descartadas"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DateDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ButtonListar As System.Windows.Forms.Button
    Friend WithEvents ButtonExportar As System.Windows.Forms.Button
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ficha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Productor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Muestra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoInforme As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MotivoDescarte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InfRetorno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Autorizacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
