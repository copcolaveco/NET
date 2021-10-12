<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormContadorAnalisisEmpresas2
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
        Me.ButtonImprimir = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Ficha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RB = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Gr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Pr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Lc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ST = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Ur = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Inh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Esp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Psi = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ButtonListar = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboEmpresas = New System.Windows.Forms.ComboBox
        Me.DateHasta = New System.Windows.Forms.DateTimePicker
        Me.DateDesde = New System.Windows.Forms.DateTimePicker
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonImprimir
        '
        Me.ButtonImprimir.Location = New System.Drawing.Point(369, 48)
        Me.ButtonImprimir.Name = "ButtonImprimir"
        Me.ButtonImprimir.Size = New System.Drawing.Size(83, 23)
        Me.ButtonImprimir.TabIndex = 17
        Me.ButtonImprimir.Text = "Generar TXT"
        Me.ButtonImprimir.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ficha, Me.Fecha, Me.RC, Me.RB, Me.Gr, Me.Pr, Me.Lc, Me.ST, Me.Cr, Me.Ur, Me.Inh, Me.Esp, Me.Psi})
        Me.DataGridView1.Location = New System.Drawing.Point(14, 94)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(785, 361)
        Me.DataGridView1.TabIndex = 16
        '
        'Ficha
        '
        Me.Ficha.HeaderText = "Ficha"
        Me.Ficha.Name = "Ficha"
        Me.Ficha.Width = 80
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 80
        '
        'RC
        '
        Me.RC.HeaderText = "RC"
        Me.RC.Name = "RC"
        Me.RC.Width = 50
        '
        'RB
        '
        Me.RB.HeaderText = "RB"
        Me.RB.Name = "RB"
        Me.RB.Width = 50
        '
        'Gr
        '
        Me.Gr.HeaderText = "Grasa"
        Me.Gr.Name = "Gr"
        Me.Gr.Width = 50
        '
        'Pr
        '
        Me.Pr.HeaderText = "Prot."
        Me.Pr.Name = "Pr"
        Me.Pr.Width = 50
        '
        'Lc
        '
        Me.Lc.HeaderText = "Lactosa"
        Me.Lc.Name = "Lc"
        Me.Lc.Width = 50
        '
        'ST
        '
        Me.ST.HeaderText = "ST"
        Me.ST.Name = "ST"
        Me.ST.Width = 50
        '
        'Cr
        '
        Me.Cr.HeaderText = "Criosc."
        Me.Cr.Name = "Cr"
        Me.Cr.Width = 50
        '
        'Ur
        '
        Me.Ur.HeaderText = "Urea"
        Me.Ur.Name = "Ur"
        Me.Ur.Width = 50
        '
        'Inh
        '
        Me.Inh.HeaderText = "Inh."
        Me.Inh.Name = "Inh"
        Me.Inh.Width = 50
        '
        'Esp
        '
        Me.Esp.HeaderText = "Espor."
        Me.Esp.Name = "Esp"
        Me.Esp.Width = 50
        '
        'Psi
        '
        Me.Psi.HeaderText = "Psicrot."
        Me.Psi.Name = "Psi"
        Me.Psi.Width = 50
        '
        'ButtonListar
        '
        Me.ButtonListar.Location = New System.Drawing.Point(288, 48)
        Me.ButtonListar.Name = "ButtonListar"
        Me.ButtonListar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonListar.TabIndex = 15
        Me.ButtonListar.Text = "Listar"
        Me.ButtonListar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Empresa"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(158, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "hasta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Desde"
        '
        'ComboEmpresas
        '
        Me.ComboEmpresas.FormattingEnabled = True
        Me.ComboEmpresas.Location = New System.Drawing.Point(65, 50)
        Me.ComboEmpresas.Name = "ComboEmpresas"
        Me.ComboEmpresas.Size = New System.Drawing.Size(208, 21)
        Me.ComboEmpresas.TabIndex = 11
        '
        'DateHasta
        '
        Me.DateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateHasta.Location = New System.Drawing.Point(197, 12)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(97, 20)
        Me.DateHasta.TabIndex = 10
        '
        'DateDesde
        '
        Me.DateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDesde.Location = New System.Drawing.Point(55, 12)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(97, 20)
        Me.DateDesde.TabIndex = 9
        '
        'FormContadorAnalisisEmpresas2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(809, 464)
        Me.Controls.Add(Me.ButtonImprimir)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ButtonListar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboEmpresas)
        Me.Controls.Add(Me.DateHasta)
        Me.Controls.Add(Me.DateDesde)
        Me.Name = "FormContadorAnalisisEmpresas2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contador de análisis de empresas (Nuevo)"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonImprimir As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Ficha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Gr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ST As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Inh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Esp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Psi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ButtonListar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboEmpresas As System.Windows.Forms.ComboBox
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateDesde As System.Windows.Forms.DateTimePicker
End Class
