<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormControlRespaldos
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
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.CheckContyA = New System.Windows.Forms.CheckBox
        Me.CheckContyM = New System.Windows.Forms.CheckBox
        Me.CheckSrvDocumentosA = New System.Windows.Forms.CheckBox
        Me.CheckSrvDocumentosM = New System.Windows.Forms.CheckBox
        Me.CheckSrv2DocumentosA = New System.Windows.Forms.CheckBox
        Me.CheckSrv2DocumentosM = New System.Windows.Forms.CheckBox
        Me.CheckG2000A = New System.Windows.Forms.CheckBox
        Me.CheckG2000M = New System.Windows.Forms.CheckBox
        Me.CheckMySQLA = New System.Windows.Forms.CheckBox
        Me.CheckMySQLM = New System.Windows.Forms.CheckBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.ButtonNuevo = New System.Windows.Forms.Button
        Me.ButtonGuardar = New System.Windows.Forms.Button
        Me.ButtonEliminar = New System.Windows.Forms.Button
        Me.CheckSrv2MySQLA = New System.Windows.Forms.CheckBox
        Me.CheckSrv2MySQLM = New System.Windows.Forms.CheckBox
        Me.Label8 = New System.Windows.Forms.Label
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(71, 19)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(51, 20)
        Me.TextBox1.TabIndex = 0
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(71, 45)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(100, 20)
        Me.DateTimePicker1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Fecha"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "SrvColaveco / Documentos"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 156)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(145, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "SRVDATOS / Documentos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 179)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Contable / Memory G2000"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(28, 202)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(144, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "IT / Respaldo de BD MySQL"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(28, 87)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "SrvColaveco / Conty"
        '
        'CheckContyA
        '
        Me.CheckContyA.AutoSize = True
        Me.CheckContyA.Location = New System.Drawing.Point(189, 86)
        Me.CheckContyA.Name = "CheckContyA"
        Me.CheckContyA.Size = New System.Drawing.Size(79, 17)
        Me.CheckContyA.TabIndex = 9
        Me.CheckContyA.Text = "Automático"
        Me.CheckContyA.UseVisualStyleBackColor = True
        '
        'CheckContyM
        '
        Me.CheckContyM.AutoSize = True
        Me.CheckContyM.Location = New System.Drawing.Point(276, 86)
        Me.CheckContyM.Name = "CheckContyM"
        Me.CheckContyM.Size = New System.Drawing.Size(61, 17)
        Me.CheckContyM.TabIndex = 10
        Me.CheckContyM.Text = "Manual"
        Me.CheckContyM.UseVisualStyleBackColor = True
        '
        'CheckSrvDocumentosA
        '
        Me.CheckSrvDocumentosA.AutoSize = True
        Me.CheckSrvDocumentosA.Location = New System.Drawing.Point(189, 110)
        Me.CheckSrvDocumentosA.Name = "CheckSrvDocumentosA"
        Me.CheckSrvDocumentosA.Size = New System.Drawing.Size(79, 17)
        Me.CheckSrvDocumentosA.TabIndex = 11
        Me.CheckSrvDocumentosA.Text = "Automático"
        Me.CheckSrvDocumentosA.UseVisualStyleBackColor = True
        '
        'CheckSrvDocumentosM
        '
        Me.CheckSrvDocumentosM.AutoSize = True
        Me.CheckSrvDocumentosM.Location = New System.Drawing.Point(276, 109)
        Me.CheckSrvDocumentosM.Name = "CheckSrvDocumentosM"
        Me.CheckSrvDocumentosM.Size = New System.Drawing.Size(61, 17)
        Me.CheckSrvDocumentosM.TabIndex = 12
        Me.CheckSrvDocumentosM.Text = "Manual"
        Me.CheckSrvDocumentosM.UseVisualStyleBackColor = True
        '
        'CheckSrv2DocumentosA
        '
        Me.CheckSrv2DocumentosA.AutoSize = True
        Me.CheckSrv2DocumentosA.Location = New System.Drawing.Point(189, 155)
        Me.CheckSrv2DocumentosA.Name = "CheckSrv2DocumentosA"
        Me.CheckSrv2DocumentosA.Size = New System.Drawing.Size(79, 17)
        Me.CheckSrv2DocumentosA.TabIndex = 13
        Me.CheckSrv2DocumentosA.Text = "Automático"
        Me.CheckSrv2DocumentosA.UseVisualStyleBackColor = True
        '
        'CheckSrv2DocumentosM
        '
        Me.CheckSrv2DocumentosM.AutoSize = True
        Me.CheckSrv2DocumentosM.Location = New System.Drawing.Point(276, 155)
        Me.CheckSrv2DocumentosM.Name = "CheckSrv2DocumentosM"
        Me.CheckSrv2DocumentosM.Size = New System.Drawing.Size(61, 17)
        Me.CheckSrv2DocumentosM.TabIndex = 14
        Me.CheckSrv2DocumentosM.Text = "Manual"
        Me.CheckSrv2DocumentosM.UseVisualStyleBackColor = True
        '
        'CheckG2000A
        '
        Me.CheckG2000A.AutoSize = True
        Me.CheckG2000A.Location = New System.Drawing.Point(189, 178)
        Me.CheckG2000A.Name = "CheckG2000A"
        Me.CheckG2000A.Size = New System.Drawing.Size(79, 17)
        Me.CheckG2000A.TabIndex = 15
        Me.CheckG2000A.Text = "Automático"
        Me.CheckG2000A.UseVisualStyleBackColor = True
        '
        'CheckG2000M
        '
        Me.CheckG2000M.AutoSize = True
        Me.CheckG2000M.Location = New System.Drawing.Point(276, 178)
        Me.CheckG2000M.Name = "CheckG2000M"
        Me.CheckG2000M.Size = New System.Drawing.Size(61, 17)
        Me.CheckG2000M.TabIndex = 16
        Me.CheckG2000M.Text = "Manual"
        Me.CheckG2000M.UseVisualStyleBackColor = True
        '
        'CheckMySQLA
        '
        Me.CheckMySQLA.AutoSize = True
        Me.CheckMySQLA.Location = New System.Drawing.Point(189, 201)
        Me.CheckMySQLA.Name = "CheckMySQLA"
        Me.CheckMySQLA.Size = New System.Drawing.Size(79, 17)
        Me.CheckMySQLA.TabIndex = 17
        Me.CheckMySQLA.Text = "Automático"
        Me.CheckMySQLA.UseVisualStyleBackColor = True
        '
        'CheckMySQLM
        '
        Me.CheckMySQLM.AutoSize = True
        Me.CheckMySQLM.Location = New System.Drawing.Point(276, 201)
        Me.CheckMySQLM.Name = "CheckMySQLM"
        Me.CheckMySQLM.Size = New System.Drawing.Size(61, 17)
        Me.CheckMySQLM.TabIndex = 18
        Me.CheckMySQLM.Text = "Manual"
        Me.CheckMySQLM.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(359, 19)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(478, 464)
        Me.DataGridView1.TabIndex = 19
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(61, 243)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNuevo.TabIndex = 20
        Me.ButtonNuevo.Text = "Nuevo"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(142, 243)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 21
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(223, 243)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEliminar.TabIndex = 22
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'CheckSrv2MySQLA
        '
        Me.CheckSrv2MySQLA.AutoSize = True
        Me.CheckSrv2MySQLA.Location = New System.Drawing.Point(188, 132)
        Me.CheckSrv2MySQLA.Name = "CheckSrv2MySQLA"
        Me.CheckSrv2MySQLA.Size = New System.Drawing.Size(79, 17)
        Me.CheckSrv2MySQLA.TabIndex = 23
        Me.CheckSrv2MySQLA.Text = "Automático"
        Me.CheckSrv2MySQLA.UseVisualStyleBackColor = True
        '
        'CheckSrv2MySQLM
        '
        Me.CheckSrv2MySQLM.AutoSize = True
        Me.CheckSrv2MySQLM.Location = New System.Drawing.Point(276, 132)
        Me.CheckSrv2MySQLM.Name = "CheckSrv2MySQLM"
        Me.CheckSrv2MySQLM.Size = New System.Drawing.Size(61, 17)
        Me.CheckSrv2MySQLM.TabIndex = 24
        Me.CheckSrv2MySQLM.Text = "Manual"
        Me.CheckSrv2MySQLM.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(28, 133)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 13)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "SRVDATOS / MySQL"
        '
        'FormControlRespaldos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(849, 495)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.CheckSrv2MySQLM)
        Me.Controls.Add(Me.CheckSrv2MySQLA)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.CheckMySQLM)
        Me.Controls.Add(Me.CheckMySQLA)
        Me.Controls.Add(Me.CheckG2000M)
        Me.Controls.Add(Me.CheckG2000A)
        Me.Controls.Add(Me.CheckSrv2DocumentosM)
        Me.Controls.Add(Me.CheckSrv2DocumentosA)
        Me.Controls.Add(Me.CheckSrvDocumentosM)
        Me.Controls.Add(Me.CheckSrvDocumentosA)
        Me.Controls.Add(Me.CheckContyM)
        Me.Controls.Add(Me.CheckContyA)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "FormControlRespaldos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control de respaldos"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CheckContyA As System.Windows.Forms.CheckBox
    Friend WithEvents CheckContyM As System.Windows.Forms.CheckBox
    Friend WithEvents CheckSrvDocumentosA As System.Windows.Forms.CheckBox
    Friend WithEvents CheckSrvDocumentosM As System.Windows.Forms.CheckBox
    Friend WithEvents CheckSrv2DocumentosA As System.Windows.Forms.CheckBox
    Friend WithEvents CheckSrv2DocumentosM As System.Windows.Forms.CheckBox
    Friend WithEvents CheckG2000A As System.Windows.Forms.CheckBox
    Friend WithEvents CheckG2000M As System.Windows.Forms.CheckBox
    Friend WithEvents CheckMySQLA As System.Windows.Forms.CheckBox
    Friend WithEvents CheckMySQLM As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents CheckSrv2MySQLA As System.Windows.Forms.CheckBox
    Friend WithEvents CheckSrv2MySQLM As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
