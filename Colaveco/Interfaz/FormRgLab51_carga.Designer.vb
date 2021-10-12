<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRgLab51_carga
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
        Me.ButtonProcesar = New System.Windows.Forms.Button
        Me.TextArchivoBentley = New System.Windows.Forms.TextBox
        Me.ButtonBuscar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextArchivoDelta1 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.TextArchivoDelta2 = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Equipo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label3 = New System.Windows.Forms.Label
        Me.DateFecha = New System.Windows.Forms.DateTimePicker
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonProcesar
        '
        Me.ButtonProcesar.Location = New System.Drawing.Point(15, 274)
        Me.ButtonProcesar.Name = "ButtonProcesar"
        Me.ButtonProcesar.Size = New System.Drawing.Size(290, 40)
        Me.ButtonProcesar.TabIndex = 9
        Me.ButtonProcesar.Text = "Procesar"
        Me.ButtonProcesar.UseVisualStyleBackColor = True
        '
        'TextArchivoBentley
        '
        Me.TextArchivoBentley.Location = New System.Drawing.Point(15, 99)
        Me.TextArchivoBentley.Name = "TextArchivoBentley"
        Me.TextArchivoBentley.Size = New System.Drawing.Size(290, 20)
        Me.TextArchivoBentley.TabIndex = 8
        '
        'ButtonBuscar
        '
        Me.ButtonBuscar.Location = New System.Drawing.Point(15, 70)
        Me.ButtonBuscar.Name = "ButtonBuscar"
        Me.ButtonBuscar.Size = New System.Drawing.Size(112, 23)
        Me.ButtonBuscar.TabIndex = 7
        Me.ButtonBuscar.Text = "Seleccionar archivo"
        Me.ButtonBuscar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Equipo Bentley (FAT)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 127)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Equipo Delta (CSV)"
        '
        'TextArchivoDelta1
        '
        Me.TextArchivoDelta1.Location = New System.Drawing.Point(15, 172)
        Me.TextArchivoDelta1.Name = "TextArchivoDelta1"
        Me.TextArchivoDelta1.Size = New System.Drawing.Size(290, 20)
        Me.TextArchivoDelta1.TabIndex = 13
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(15, 143)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(126, 23)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Seleccionar archivo 1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextArchivoDelta2
        '
        Me.TextArchivoDelta2.Location = New System.Drawing.Point(15, 227)
        Me.TextArchivoDelta2.Name = "TextArchivoDelta2"
        Me.TextArchivoDelta2.Size = New System.Drawing.Size(290, 20)
        Me.TextArchivoDelta2.TabIndex = 15
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(15, 198)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(126, 23)
        Me.Button2.TabIndex = 14
        Me.Button2.Text = "Seleccionar archivo 2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Equipo, Me.Fecha})
        Me.DataGridView1.Location = New System.Drawing.Point(339, 99)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(185, 150)
        Me.DataGridView1.TabIndex = 16
        '
        'Equipo
        '
        Me.Equipo.HeaderText = "Equipo"
        Me.Equipo.Name = "Equipo"
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 80
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(336, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Último procesamiento"
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(15, 12)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(106, 20)
        Me.DateFecha.TabIndex = 18
        '
        'FormRgLab51_carga
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(533, 325)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.TextArchivoDelta2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TextArchivoDelta1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonProcesar)
        Me.Controls.Add(Me.TextArchivoBentley)
        Me.Controls.Add(Me.ButtonBuscar)
        Me.Name = "FormRgLab51_carga"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RG. LAB. 51 (Carga de datos)"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonProcesar As System.Windows.Forms.Button
    Friend WithEvents TextArchivoBentley As System.Windows.Forms.TextBox
    Friend WithEvents ButtonBuscar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextArchivoDelta1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextArchivoDelta2 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Equipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
End Class
