﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormValoresEmpresa
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Ficha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Grasa = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Proteina = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Lactosa = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ST = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Crioscopia = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Urea = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PriteinaV = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Caseina = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Densidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PH = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ButtonListar = New System.Windows.Forms.Button
        Me.TextIdProductor = New System.Windows.Forms.TextBox
        Me.TextNombreProductor = New System.Windows.Forms.TextBox
        Me.ButtonBuscarProductor = New System.Windows.Forms.Button
        Me.ButtonExportar = New System.Windows.Forms.Button
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DateDesde
        '
        Me.DateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDesde.Location = New System.Drawing.Point(12, 29)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(90, 20)
        Me.DateDesde.TabIndex = 3
        '
        'DateHasta
        '
        Me.DateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateHasta.Location = New System.Drawing.Point(108, 30)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(90, 20)
        Me.DateHasta.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Desde"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(105, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Hasta"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Ficha, Me.RC, Me.Grasa, Me.Proteina, Me.Lactosa, Me.ST, Me.Crioscopia, Me.Urea, Me.PriteinaV, Me.Caseina, Me.Densidad, Me.PH})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 85)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(985, 533)
        Me.DataGridView1.TabIndex = 28
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
        '
        'RC
        '
        Me.RC.HeaderText = "RC"
        Me.RC.Name = "RC"
        Me.RC.Width = 80
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
        'ST
        '
        Me.ST.HeaderText = "ST"
        Me.ST.Name = "ST"
        Me.ST.Width = 80
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
        'PriteinaV
        '
        Me.PriteinaV.HeaderText = "Proteina V."
        Me.PriteinaV.Name = "PriteinaV"
        Me.PriteinaV.Width = 80
        '
        'Caseina
        '
        Me.Caseina.HeaderText = "Caseína"
        Me.Caseina.Name = "Caseina"
        Me.Caseina.Width = 80
        '
        'Densidad
        '
        Me.Densidad.HeaderText = "Densidad"
        Me.Densidad.Name = "Densidad"
        Me.Densidad.Width = 80
        '
        'PH
        '
        Me.PH.HeaderText = "pH"
        Me.PH.Name = "PH"
        Me.PH.Width = 80
        '
        'ButtonListar
        '
        Me.ButtonListar.Location = New System.Drawing.Point(573, 26)
        Me.ButtonListar.Name = "ButtonListar"
        Me.ButtonListar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonListar.TabIndex = 29
        Me.ButtonListar.Text = "Listar"
        Me.ButtonListar.UseVisualStyleBackColor = True
        '
        'TextIdProductor
        '
        Me.TextIdProductor.Location = New System.Drawing.Point(229, 29)
        Me.TextIdProductor.Name = "TextIdProductor"
        Me.TextIdProductor.ReadOnly = True
        Me.TextIdProductor.Size = New System.Drawing.Size(52, 20)
        Me.TextIdProductor.TabIndex = 30
        '
        'TextNombreProductor
        '
        Me.TextNombreProductor.Location = New System.Drawing.Point(315, 29)
        Me.TextNombreProductor.Name = "TextNombreProductor"
        Me.TextNombreProductor.ReadOnly = True
        Me.TextNombreProductor.Size = New System.Drawing.Size(243, 20)
        Me.TextNombreProductor.TabIndex = 31
        '
        'ButtonBuscarProductor
        '
        Me.ButtonBuscarProductor.Location = New System.Drawing.Point(287, 27)
        Me.ButtonBuscarProductor.Name = "ButtonBuscarProductor"
        Me.ButtonBuscarProductor.Size = New System.Drawing.Size(22, 23)
        Me.ButtonBuscarProductor.TabIndex = 32
        Me.ButtonBuscarProductor.Text = "^"
        Me.ButtonBuscarProductor.UseVisualStyleBackColor = True
        '
        'ButtonExportar
        '
        Me.ButtonExportar.Location = New System.Drawing.Point(654, 27)
        Me.ButtonExportar.Name = "ButtonExportar"
        Me.ButtonExportar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonExportar.TabIndex = 33
        Me.ButtonExportar.Text = "Excel"
        Me.ButtonExportar.UseVisualStyleBackColor = True
        '
        'FormValoresEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1007, 630)
        Me.Controls.Add(Me.ButtonExportar)
        Me.Controls.Add(Me.ButtonBuscarProductor)
        Me.Controls.Add(Me.TextNombreProductor)
        Me.Controls.Add(Me.TextIdProductor)
        Me.Controls.Add(Me.ButtonListar)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateHasta)
        Me.Controls.Add(Me.DateDesde)
        Me.Name = "FormValoresEmpresa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Empresa"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DateDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonListar As System.Windows.Forms.Button
    Friend WithEvents TextIdProductor As System.Windows.Forms.TextBox
    Friend WithEvents TextNombreProductor As System.Windows.Forms.TextBox
    Friend WithEvents ButtonBuscarProductor As System.Windows.Forms.Button
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ficha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Grasa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Proteina As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lactosa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ST As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Crioscopia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Urea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PriteinaV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Caseina As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Densidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ButtonExportar As System.Windows.Forms.Button
End Class
