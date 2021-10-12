<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormControlInformesSuelos
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
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaControl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ficha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Resultado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Coincide = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.OM = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.NC = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Controlador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VerInforme = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Controlada = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.FechaControl, Me.Ficha, Me.Fecha, Me.Tipo, Me.Resultado, Me.Coincide, Me.OM, Me.NC, Me.Observaciones, Me.Controlador, Me.VerInforme, Me.Controlada})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 11)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(757, 426)
        Me.DataGridView1.TabIndex = 11
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'FechaControl
        '
        Me.FechaControl.HeaderText = "FechaControl"
        Me.FechaControl.Name = "FechaControl"
        Me.FechaControl.Visible = False
        '
        'Ficha
        '
        Me.Ficha.HeaderText = "Ficha"
        Me.Ficha.Name = "Ficha"
        Me.Ficha.Width = 75
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 75
        '
        'Tipo
        '
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.Width = 120
        '
        'Resultado
        '
        Me.Resultado.HeaderText = "Resultado"
        Me.Resultado.Name = "Resultado"
        Me.Resultado.Width = 57
        '
        'Coincide
        '
        Me.Coincide.HeaderText = "Coincide"
        Me.Coincide.Name = "Coincide"
        Me.Coincide.Width = 55
        '
        'OM
        '
        Me.OM.HeaderText = "OM"
        Me.OM.Name = "OM"
        Me.OM.Width = 30
        '
        'NC
        '
        Me.NC.HeaderText = "NC"
        Me.NC.Name = "NC"
        Me.NC.Width = 30
        '
        'Observaciones
        '
        Me.Observaciones.HeaderText = "Observaciones"
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.Width = 150
        '
        'Controlador
        '
        Me.Controlador.HeaderText = "Controlador"
        Me.Controlador.Name = "Controlador"
        Me.Controlador.Visible = False
        '
        'VerInforme
        '
        Me.VerInforme.HeaderText = "Ver Informe"
        Me.VerInforme.Name = "VerInforme"
        '
        'Controlada
        '
        Me.Controlada.HeaderText = "Controlada"
        Me.Controlada.Name = "Controlada"
        Me.Controlada.Width = 60
        '
        'FormControlInformesSuelos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(780, 448)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FormControlInformesSuelos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control de Informes de Suelos"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaControl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ficha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Resultado As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Coincide As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents OM As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents NC As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Controlador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VerInforme As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Controlada As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
