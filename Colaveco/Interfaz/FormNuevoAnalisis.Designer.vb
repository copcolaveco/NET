<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormNuevoAnalisis
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
        Me.Fichas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.id2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Muestras = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Detalle = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.Id3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Analisis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Resultado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cargar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Metodo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Met = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Unidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Uni = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Eliminar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.ButtonFinalizar = New System.Windows.Forms.Button()
        Me.DateFecha = New System.Windows.Forms.DateTimePicker()
        Me.TextObsInternas = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView4 = New System.Windows.Forms.DataGridView()
        Me.Id4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Analisis2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Resultado2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cargar2 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Metodo2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Met2 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Unidad2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Uni2 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Laboratorio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lab2 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.X = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextDetalle = New System.Windows.Forms.TextBox()
        Me.DataGridView5 = New System.Windows.Forms.DataGridView()
        Me.Id5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Muestras2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboLaboratorios = New System.Windows.Forms.ComboBox()
        Me.ButtonCompletarLaboratorio = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Fichas})
        Me.DataGridView1.Location = New System.Drawing.Point(16, 97)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(159, 666)
        Me.DataGridView1.TabIndex = 0
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'Fichas
        '
        Me.Fichas.HeaderText = "Fichas"
        Me.Fichas.Name = "Fichas"
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id2, Me.Muestras, Me.Detalle})
        Me.DataGridView2.Location = New System.Drawing.Point(199, 97)
        Me.DataGridView2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.Size = New System.Drawing.Size(273, 385)
        Me.DataGridView2.TabIndex = 1
        '
        'id2
        '
        Me.id2.HeaderText = "Id2"
        Me.id2.Name = "id2"
        Me.id2.Visible = False
        '
        'Muestras
        '
        Me.Muestras.HeaderText = "Muestras"
        Me.Muestras.Name = "Muestras"
        Me.Muestras.Width = 150
        '
        'Detalle
        '
        Me.Detalle.HeaderText = ""
        Me.Detalle.Name = "Detalle"
        Me.Detalle.Text = "+"
        Me.Detalle.UseColumnTextForButtonValue = True
        Me.Detalle.Width = 40
        '
        'DataGridView3
        '
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id3, Me.Analisis, Me.Resultado, Me.Cargar, Me.Metodo, Me.Met, Me.Unidad, Me.Uni, Me.Eliminar})
        Me.DataGridView3.Location = New System.Drawing.Point(481, 97)
        Me.DataGridView3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.RowHeadersVisible = False
        Me.DataGridView3.Size = New System.Drawing.Size(1064, 385)
        Me.DataGridView3.TabIndex = 2
        '
        'Id3
        '
        Me.Id3.HeaderText = "Id3"
        Me.Id3.Name = "Id3"
        Me.Id3.Visible = False
        '
        'Analisis
        '
        Me.Analisis.HeaderText = "Análisis"
        Me.Analisis.Name = "Analisis"
        Me.Analisis.ReadOnly = True
        Me.Analisis.Width = 280
        '
        'Resultado
        '
        Me.Resultado.HeaderText = "Resultado"
        Me.Resultado.Name = "Resultado"
        Me.Resultado.ReadOnly = True
        '
        'Cargar
        '
        Me.Cargar.HeaderText = ""
        Me.Cargar.Name = "Cargar"
        Me.Cargar.Text = "Cargar"
        Me.Cargar.UseColumnTextForButtonValue = True
        '
        'Metodo
        '
        Me.Metodo.HeaderText = "Método"
        Me.Metodo.Name = "Metodo"
        '
        'Met
        '
        Me.Met.HeaderText = ""
        Me.Met.Name = "Met"
        Me.Met.Text = "+"
        Me.Met.UseColumnTextForButtonValue = True
        Me.Met.Width = 20
        '
        'Unidad
        '
        Me.Unidad.HeaderText = "Unidad"
        Me.Unidad.Name = "Unidad"
        '
        'Uni
        '
        Me.Uni.HeaderText = ""
        Me.Uni.Name = "Uni"
        Me.Uni.Text = "+"
        Me.Uni.UseColumnTextForButtonValue = True
        Me.Uni.Width = 20
        '
        'Eliminar
        '
        Me.Eliminar.HeaderText = ""
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.Text = "e"
        Me.Eliminar.UseColumnTextForButtonValue = True
        Me.Eliminar.Width = 20
        '
        'ButtonFinalizar
        '
        Me.ButtonFinalizar.Location = New System.Drawing.Point(1413, 759)
        Me.ButtonFinalizar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonFinalizar.Name = "ButtonFinalizar"
        Me.ButtonFinalizar.Size = New System.Drawing.Size(132, 28)
        Me.ButtonFinalizar.TabIndex = 3
        Me.ButtonFinalizar.Text = "Finalizar"
        Me.ButtonFinalizar.UseVisualStyleBackColor = True
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(144, 11)
        Me.DateFecha.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(128, 22)
        Me.DateFecha.TabIndex = 4
        '
        'TextObsInternas
        '
        Me.TextObsInternas.BackColor = System.Drawing.SystemColors.Info
        Me.TextObsInternas.Location = New System.Drawing.Point(1048, 31)
        Me.TextObsInternas.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextObsInternas.Multiline = True
        Me.TextObsInternas.Name = "TextObsInternas"
        Me.TextObsInternas.Size = New System.Drawing.Size(439, 58)
        Me.TextObsInternas.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1044, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(158, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Observaciones internas"
        '
        'DataGridView4
        '
        Me.DataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView4.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id4, Me.Analisis2, Me.Resultado2, Me.Cargar2, Me.Metodo2, Me.Met2, Me.Unidad2, Me.Uni2, Me.Laboratorio, Me.Lab2, Me.X})
        Me.DataGridView4.Location = New System.Drawing.Point(481, 511)
        Me.DataGridView4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView4.Name = "DataGridView4"
        Me.DataGridView4.RowHeadersVisible = False
        Me.DataGridView4.Size = New System.Drawing.Size(1064, 241)
        Me.DataGridView4.TabIndex = 7
        '
        'Id4
        '
        Me.Id4.HeaderText = "Id4"
        Me.Id4.Name = "Id4"
        Me.Id4.Visible = False
        '
        'Analisis2
        '
        Me.Analisis2.HeaderText = "Analisis"
        Me.Analisis2.Name = "Analisis2"
        Me.Analisis2.Width = 200
        '
        'Resultado2
        '
        Me.Resultado2.HeaderText = "Resultado"
        Me.Resultado2.Name = "Resultado2"
        Me.Resultado2.Width = 80
        '
        'Cargar2
        '
        Me.Cargar2.HeaderText = ""
        Me.Cargar2.Name = "Cargar2"
        Me.Cargar2.Text = "Cargar"
        Me.Cargar2.UseColumnTextForButtonValue = True
        '
        'Metodo2
        '
        Me.Metodo2.HeaderText = "Método"
        Me.Metodo2.Name = "Metodo2"
        '
        'Met2
        '
        Me.Met2.HeaderText = ""
        Me.Met2.Name = "Met2"
        Me.Met2.Text = "+"
        Me.Met2.UseColumnTextForButtonValue = True
        Me.Met2.Width = 20
        '
        'Unidad2
        '
        Me.Unidad2.HeaderText = "Unidad"
        Me.Unidad2.Name = "Unidad2"
        '
        'Uni2
        '
        Me.Uni2.HeaderText = ""
        Me.Uni2.Name = "Uni2"
        Me.Uni2.Text = "+"
        Me.Uni2.UseColumnTextForButtonValue = True
        Me.Uni2.Width = 20
        '
        'Laboratorio
        '
        Me.Laboratorio.HeaderText = "Laboratorio"
        Me.Laboratorio.Name = "Laboratorio"
        '
        'Lab2
        '
        Me.Lab2.HeaderText = ""
        Me.Lab2.Name = "Lab2"
        Me.Lab2.Text = "+"
        Me.Lab2.UseColumnTextForButtonValue = True
        Me.Lab2.Width = 20
        '
        'X
        '
        Me.X.HeaderText = ""
        Me.X.Name = "X"
        Me.X.Text = "X"
        Me.X.UseColumnTextForButtonValue = True
        Me.X.Width = 30
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(195, 491)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(179, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "ANÁLISIS TERCERIZADOS"
        '
        'TextDetalle
        '
        Me.TextDetalle.Location = New System.Drawing.Point(481, 65)
        Me.TextDetalle.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextDetalle.Name = "TextDetalle"
        Me.TextDetalle.ReadOnly = True
        Me.TextDetalle.Size = New System.Drawing.Size(557, 22)
        Me.TextDetalle.TabIndex = 9
        '
        'DataGridView5
        '
        Me.DataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView5.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id5, Me.Muestras2})
        Me.DataGridView5.Location = New System.Drawing.Point(199, 511)
        Me.DataGridView5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView5.Name = "DataGridView5"
        Me.DataGridView5.RowHeadersVisible = False
        Me.DataGridView5.Size = New System.Drawing.Size(273, 241)
        Me.DataGridView5.TabIndex = 10
        '
        'Id5
        '
        Me.Id5.HeaderText = "Id5"
        Me.Id5.Name = "Id5"
        Me.Id5.Visible = False
        '
        'Muestras2
        '
        Me.Muestras2.HeaderText = "Muestras"
        Me.Muestras2.Name = "Muestras2"
        Me.Muestras2.Width = 180
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 11)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 17)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Fecha de proceso"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(207, 78)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(252, 17)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "(+) Para ingresar detalle de la muestra"
        '
        'ComboLaboratorios
        '
        Me.ComboLaboratorios.FormattingEnabled = True
        Me.ComboLaboratorios.Location = New System.Drawing.Point(981, 762)
        Me.ComboLaboratorios.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboLaboratorios.Name = "ComboLaboratorios"
        Me.ComboLaboratorios.Size = New System.Drawing.Size(213, 24)
        Me.ComboLaboratorios.TabIndex = 13
        '
        'ButtonCompletarLaboratorio
        '
        Me.ButtonCompletarLaboratorio.Location = New System.Drawing.Point(1204, 759)
        Me.ButtonCompletarLaboratorio.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonCompletarLaboratorio.Name = "ButtonCompletarLaboratorio"
        Me.ButtonCompletarLaboratorio.Size = New System.Drawing.Size(164, 28)
        Me.ButtonCompletarLaboratorio.TabIndex = 14
        Me.ButtonCompletarLaboratorio.Text = "Completar Laboratorio"
        Me.ButtonCompletarLaboratorio.UseVisualStyleBackColor = True
        '
        'FormNuevoAnalisis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1563, 795)
        Me.Controls.Add(Me.ButtonCompletarLaboratorio)
        Me.Controls.Add(Me.ComboLaboratorios)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DataGridView5)
        Me.Controls.Add(Me.TextDetalle)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DataGridView4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextObsInternas)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.ButtonFinalizar)
        Me.Controls.Add(Me.DataGridView3)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FormNuevoAnalisis"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nuevo Análisis"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fichas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView3 As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonFinalizar As System.Windows.Forms.Button
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextObsInternas As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridView4 As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextDetalle As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView5 As System.Windows.Forms.DataGridView
    Friend WithEvents Id5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Muestras2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents id2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Muestras As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Detalle As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Id3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Analisis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Resultado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cargar As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Metodo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Met As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Unidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Uni As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Eliminar As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents ComboLaboratorios As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonCompletarLaboratorio As System.Windows.Forms.Button
    Friend WithEvents Id4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Analisis2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Resultado2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cargar2 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Metodo2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Met2 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Unidad2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Uni2 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Laboratorio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lab2 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents X As System.Windows.Forms.DataGridViewButtonColumn
End Class
