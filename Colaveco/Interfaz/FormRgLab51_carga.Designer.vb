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
        Me.ButtonProcesar = New System.Windows.Forms.Button()
        Me.TextArchivoBentley = New System.Windows.Forms.TextBox()
        Me.ButtonBuscar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextArchivoDelta1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextArchivoDelta2 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Equipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextArchivoB6 = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonProcesar
        '
        Me.ButtonProcesar.Location = New System.Drawing.Point(20, 337)
        Me.ButtonProcesar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonProcesar.Name = "ButtonProcesar"
        Me.ButtonProcesar.Size = New System.Drawing.Size(387, 49)
        Me.ButtonProcesar.TabIndex = 9
        Me.ButtonProcesar.Text = "Procesar"
        Me.ButtonProcesar.UseVisualStyleBackColor = True
        '
        'TextArchivoBentley
        '
        Me.TextArchivoBentley.Location = New System.Drawing.Point(20, 122)
        Me.TextArchivoBentley.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextArchivoBentley.Name = "TextArchivoBentley"
        Me.TextArchivoBentley.Size = New System.Drawing.Size(385, 22)
        Me.TextArchivoBentley.TabIndex = 8
        '
        'ButtonBuscar
        '
        Me.ButtonBuscar.Location = New System.Drawing.Point(20, 86)
        Me.ButtonBuscar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonBuscar.Name = "ButtonBuscar"
        Me.ButtonBuscar.Size = New System.Drawing.Size(149, 28)
        Me.ButtonBuscar.TabIndex = 7
        Me.ButtonBuscar.Text = "Seleccionar archivo"
        Me.ButtonBuscar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 65)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 17)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Equipo Bentley (FAT)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 193)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 17)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Equipo Delta (CSV)"
        '
        'TextArchivoDelta1
        '
        Me.TextArchivoDelta1.Location = New System.Drawing.Point(13, 250)
        Me.TextArchivoDelta1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextArchivoDelta1.Name = "TextArchivoDelta1"
        Me.TextArchivoDelta1.Size = New System.Drawing.Size(385, 22)
        Me.TextArchivoDelta1.TabIndex = 13
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(13, 214)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(168, 28)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Seleccionar archivo 1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextArchivoDelta2
        '
        Me.TextArchivoDelta2.Location = New System.Drawing.Point(420, 250)
        Me.TextArchivoDelta2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextArchivoDelta2.Name = "TextArchivoDelta2"
        Me.TextArchivoDelta2.Size = New System.Drawing.Size(385, 22)
        Me.TextArchivoDelta2.TabIndex = 15
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(420, 214)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(168, 28)
        Me.Button2.TabIndex = 14
        Me.Button2.Text = "Seleccionar archivo 2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Equipo, Me.Fecha})
        Me.DataGridView1.Location = New System.Drawing.Point(1034, 122)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(247, 185)
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
        Me.Label3.Location = New System.Drawing.Point(1031, 92)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 17)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Último procesamiento"
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(20, 15)
        Me.DateFecha.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(140, 22)
        Me.DateFecha.TabIndex = 18
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(417, 66)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(171, 17)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Equipo Bentley 600 (FAT)"
        '
        'TextArchivoB6
        '
        Me.TextArchivoB6.Location = New System.Drawing.Point(421, 122)
        Me.TextArchivoB6.Margin = New System.Windows.Forms.Padding(4)
        Me.TextArchivoB6.Name = "TextArchivoB6"
        Me.TextArchivoB6.Size = New System.Drawing.Size(385, 22)
        Me.TextArchivoB6.TabIndex = 20
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(421, 86)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(149, 28)
        Me.Button3.TabIndex = 19
        Me.Button3.Text = "Seleccionar archivo"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'FormRgLab51_carga
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1421, 463)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextArchivoB6)
        Me.Controls.Add(Me.Button3)
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
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextArchivoB6 As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
