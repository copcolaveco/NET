<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormControlBentleyDelta
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Hora = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Equipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Grasa = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Proteina = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Lactosa = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SolTotales = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Celulas = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Crioscopia = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Urea = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Valido = New System.Windows.Forms.DataGridViewButtonColumn
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Fecha, Me.Hora, Me.Equipo, Me.Grasa, Me.Proteina, Me.Lactosa, Me.SolTotales, Me.Celulas, Me.Crioscopia, Me.Urea, Me.Valido})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 41)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(837, 625)
        Me.DataGridView1.TabIndex = 0
        '
        'Id
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Id.DefaultCellStyle = DataGridViewCellStyle1
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'Fecha
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Fecha.DefaultCellStyle = DataGridViewCellStyle2
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 80
        '
        'Hora
        '
        Me.Hora.HeaderText = "Hora"
        Me.Hora.Name = "Hora"
        Me.Hora.Width = 60
        '
        'Equipo
        '
        Me.Equipo.HeaderText = "Equipo"
        Me.Equipo.Name = "Equipo"
        Me.Equipo.Width = 50
        '
        'Grasa
        '
        Me.Grasa.HeaderText = "Grasa"
        Me.Grasa.Name = "Grasa"
        Me.Grasa.Width = 80
        '
        'Proteina
        '
        Me.Proteina.HeaderText = "Proteína"
        Me.Proteina.Name = "Proteina"
        Me.Proteina.Width = 80
        '
        'Lactosa
        '
        Me.Lactosa.HeaderText = "Lactosa"
        Me.Lactosa.Name = "Lactosa"
        Me.Lactosa.Width = 80
        '
        'SolTotales
        '
        Me.SolTotales.HeaderText = "S. Totales"
        Me.SolTotales.Name = "SolTotales"
        Me.SolTotales.Width = 80
        '
        'Celulas
        '
        Me.Celulas.HeaderText = "Células"
        Me.Celulas.Name = "Celulas"
        Me.Celulas.Width = 80
        '
        'Crioscopia
        '
        Me.Crioscopia.HeaderText = "Crioscopía"
        Me.Crioscopia.Name = "Crioscopia"
        Me.Crioscopia.Width = 80
        '
        'Urea
        '
        Me.Urea.HeaderText = "Urea"
        Me.Urea.Name = "Urea"
        Me.Urea.Width = 80
        '
        'Valido
        '
        Me.Valido.HeaderText = ""
        Me.Valido.Name = "Valido"
        Me.Valido.Text = "Validar"
        Me.Valido.UseColumnTextForButtonValue = True
        Me.Valido.Width = 80
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(120, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Controles anteriores"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FormControlBentleyDelta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(859, 678)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FormControlBentleyDelta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control Bentley Delta"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Hora As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Equipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Grasa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Proteina As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lactosa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SolTotales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Celulas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Crioscopia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Urea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Valido As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
