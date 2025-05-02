<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormHistoricoSolicitudesAutorizadas
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.desde = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.hasta = New System.Windows.Forms.DateTimePicker()
        Me.ficha = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.solicitudAnalisisId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuairoAutorizador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Motivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.solicitudAnalisisId, Me.usuairoAutorizador, Me.fecha, Me.Motivo})
        Me.DataGridView1.Location = New System.Drawing.Point(183, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(775, 498)
        Me.DataGridView1.TabIndex = 0
        '
        'desde
        '
        Me.desde.Location = New System.Drawing.Point(12, 46)
        Me.desde.Name = "desde"
        Me.desde.Size = New System.Drawing.Size(138, 22)
        Me.desde.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Desde"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Hasta"
        '
        'hasta
        '
        Me.hasta.Location = New System.Drawing.Point(12, 105)
        Me.hasta.Name = "hasta"
        Me.hasta.Size = New System.Drawing.Size(138, 22)
        Me.hasta.TabIndex = 4
        '
        'ficha
        '
        Me.ficha.Location = New System.Drawing.Point(12, 166)
        Me.ficha.Name = "ficha"
        Me.ficha.Size = New System.Drawing.Size(138, 22)
        Me.ficha.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 143)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Solicitud"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 218)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(138, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Filtrar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 247)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(138, 23)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "EXCEL"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'solicitudAnalisisId
        '
        Me.solicitudAnalisisId.HeaderText = "Solicitud"
        Me.solicitudAnalisisId.Name = "solicitudAnalisisId"
        Me.solicitudAnalisisId.ReadOnly = True
        '
        'usuairoAutorizador
        '
        Me.usuairoAutorizador.HeaderText = "Usuario"
        Me.usuairoAutorizador.Name = "usuairoAutorizador"
        Me.usuairoAutorizador.ReadOnly = True
        '
        'fecha
        '
        Me.fecha.HeaderText = "Fecha"
        Me.fecha.Name = "fecha"
        Me.fecha.ReadOnly = True
        '
        'Motivo
        '
        Me.Motivo.HeaderText = "Motivo"
        Me.Motivo.Name = "Motivo"
        '
        'FormHistoricoSolicitudesAutorizadas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(970, 522)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ficha)
        Me.Controls.Add(Me.hasta)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.desde)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FormHistoricoSolicitudesAutorizadas"
        Me.Text = "FormHistoricoSolicitudesAutorizadas"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents ficha As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents solicitudAnalisisId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents usuairoAutorizador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Motivo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
