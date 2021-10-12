<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLicencias
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
        Me.DateDesde = New System.Windows.Forms.DateTimePicker
        Me.DateHasta = New System.Windows.Forms.DateTimePicker
        Me.ComboUsuarios = New System.Windows.Forms.ComboBox
        Me.ButtonGuardar = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.TextId = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextDias = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.TextDiasCorrespondientes = New System.Windows.Forms.TextBox
        Me.TextDiasRestantes = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Desde = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Hasta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Dias = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Aprobada = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Imprimir = New System.Windows.Forms.DataGridViewButtonColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DateDesde
        '
        Me.DateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDesde.Location = New System.Drawing.Point(225, 74)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(109, 20)
        Me.DateDesde.TabIndex = 0
        '
        'DateHasta
        '
        Me.DateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateHasta.Location = New System.Drawing.Point(340, 73)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(109, 20)
        Me.DateHasta.TabIndex = 1
        '
        'ComboUsuarios
        '
        Me.ComboUsuarios.FormattingEnabled = True
        Me.ComboUsuarios.Location = New System.Drawing.Point(12, 73)
        Me.ComboUsuarios.Name = "ComboUsuarios"
        Me.ComboUsuarios.Size = New System.Drawing.Size(207, 21)
        Me.ComboUsuarios.TabIndex = 2
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(523, 70)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 3
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Nombre, Me.Desde, Me.Hasta, Me.Dias, Me.Aprobada, Me.Imprimir})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 137)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(668, 446)
        Me.DataGridView1.TabIndex = 4
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(34, 47)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(43, 20)
        Me.TextId.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 586)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(356, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "(*) Si la licencia a tomar es de una año a otro, cargar una licencia por año."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 599)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(181, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Ejemplo:  20/12/2015 a 05/01/2016"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 621)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(338, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Cargar de 20/12/2015 a 31/12/2015 y de 01/01/2016 a 05/01/2016"
        '
        'TextDias
        '
        Me.TextDias.Location = New System.Drawing.Point(455, 73)
        Me.TextDias.Name = "TextDias"
        Me.TextDias.Size = New System.Drawing.Size(46, 20)
        Me.TextDias.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(462, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Días"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(225, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Desde"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(340, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Hasta"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(96, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(431, 20)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "*** Los días de licencia anual se pueden tomar hasta"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(142, 29)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(328, 20)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = " en 2 períodos por año como máximo ***"
        '
        'TextDiasCorrespondientes
        '
        Me.TextDiasCorrespondientes.Location = New System.Drawing.Point(314, 100)
        Me.TextDiasCorrespondientes.Name = "TextDiasCorrespondientes"
        Me.TextDiasCorrespondientes.Size = New System.Drawing.Size(46, 20)
        Me.TextDiasCorrespondientes.TabIndex = 16
        '
        'TextDiasRestantes
        '
        Me.TextDiasRestantes.Location = New System.Drawing.Point(455, 100)
        Me.TextDiasRestantes.Name = "TextDiasRestantes"
        Me.TextDiasRestantes.Size = New System.Drawing.Size(46, 20)
        Me.TextDiasRestantes.TabIndex = 17
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(194, 103)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(114, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Días correspondientes"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(373, 103)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(76, 13)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Días restantes"
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Width = 200
        '
        'Desde
        '
        Me.Desde.HeaderText = "Desde"
        Me.Desde.Name = "Desde"
        Me.Desde.Width = 80
        '
        'Hasta
        '
        Me.Hasta.HeaderText = "Hasta"
        Me.Hasta.Name = "Hasta"
        Me.Hasta.Width = 80
        '
        'Dias
        '
        Me.Dias.HeaderText = "Días"
        Me.Dias.Name = "Dias"
        Me.Dias.Width = 50
        '
        'Aprobada
        '
        Me.Aprobada.HeaderText = "Aprobada"
        Me.Aprobada.Name = "Aprobada"
        '
        'Imprimir
        '
        Me.Imprimir.HeaderText = ""
        Me.Imprimir.Name = "Imprimir"
        Me.Imprimir.Text = "Imprimir"
        Me.Imprimir.UseColumnTextForButtonValue = True
        '
        'FormLicencias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 642)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TextDiasRestantes)
        Me.Controls.Add(Me.TextDiasCorrespondientes)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextDias)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ComboUsuarios)
        Me.Controls.Add(Me.DateHasta)
        Me.Controls.Add(Me.DateDesde)
        Me.Name = "FormLicencias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Licencias"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DateDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents ComboUsuarios As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextDias As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextDiasCorrespondientes As System.Windows.Forms.TextBox
    Friend WithEvents TextDiasRestantes As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Desde As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Hasta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Dias As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Aprobada As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Imprimir As System.Windows.Forms.DataGridViewButtonColumn
End Class
