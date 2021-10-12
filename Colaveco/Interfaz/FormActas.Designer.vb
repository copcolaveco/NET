<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormActas
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
        Me.TextIdActa = New System.Windows.Forms.TextBox()
        Me.TextNumero = New System.Windows.Forms.TextBox()
        Me.DateFecha = New System.Windows.Forms.DateTimePicker()
        Me.TextHora = New System.Windows.Forms.TextBox()
        Me.ComboGrupo = New System.Windows.Forms.ComboBox()
        Me.TextPresentes = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ButtonGuardarActa = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdActa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tema = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Resumen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Responsable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Plazo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Efectuado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextId = New System.Windows.Forms.TextBox()
        Me.TextResumen = New System.Windows.Forms.TextBox()
        Me.TextResponsables = New System.Windows.Forms.TextBox()
        Me.CheckEfectuado = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ButtonGuardarItem = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextLugar = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.DatePlazo = New System.Windows.Forms.DateTimePicker()
        Me.ButtonEliminar = New System.Windows.Forms.Button()
        Me.ComboTema = New System.Windows.Forms.ComboBox()
        Me.ComboTitular = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ComboTitular2 = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ButtonImprimir = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextIdActa
        '
        Me.TextIdActa.Location = New System.Drawing.Point(12, 82)
        Me.TextIdActa.Name = "TextIdActa"
        Me.TextIdActa.ReadOnly = True
        Me.TextIdActa.Size = New System.Drawing.Size(51, 20)
        Me.TextIdActa.TabIndex = 0
        '
        'TextNumero
        '
        Me.TextNumero.Location = New System.Drawing.Point(373, 80)
        Me.TextNumero.Name = "TextNumero"
        Me.TextNumero.Size = New System.Drawing.Size(72, 20)
        Me.TextNumero.TabIndex = 1
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(69, 82)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(104, 20)
        Me.DateFecha.TabIndex = 2
        '
        'TextHora
        '
        Me.TextHora.Location = New System.Drawing.Point(179, 82)
        Me.TextHora.Name = "TextHora"
        Me.TextHora.Size = New System.Drawing.Size(61, 20)
        Me.TextHora.TabIndex = 3
        '
        'ComboGrupo
        '
        Me.ComboGrupo.FormattingEnabled = True
        Me.ComboGrupo.Location = New System.Drawing.Point(246, 81)
        Me.ComboGrupo.Name = "ComboGrupo"
        Me.ComboGrupo.Size = New System.Drawing.Size(121, 21)
        Me.ComboGrupo.TabIndex = 4
        '
        'TextPresentes
        '
        Me.TextPresentes.Location = New System.Drawing.Point(578, 80)
        Me.TextPresentes.Name = "TextPresentes"
        Me.TextPresentes.Size = New System.Drawing.Size(319, 20)
        Me.TextPresentes.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(95, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Fecha"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(376, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Acta Nº./Año"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(193, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Hora"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(286, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Grupo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(494, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Lugar"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(613, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Presentes"
        '
        'ButtonGuardarActa
        '
        Me.ButtonGuardarActa.Location = New System.Drawing.Point(12, 120)
        Me.ButtonGuardarActa.Name = "ButtonGuardarActa"
        Me.ButtonGuardarActa.Size = New System.Drawing.Size(217, 23)
        Me.ButtonGuardarActa.TabIndex = 14
        Me.ButtonGuardarActa.Text = "Guardar acta / ingresar items"
        Me.ButtonGuardarActa.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.IdActa, Me.Tema, Me.Resumen, Me.Responsable, Me.Plazo, Me.Efectuado})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 281)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(957, 260)
        Me.DataGridView1.TabIndex = 15
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'IdActa
        '
        Me.IdActa.HeaderText = "IdActa"
        Me.IdActa.Name = "IdActa"
        Me.IdActa.Visible = False
        '
        'Tema
        '
        Me.Tema.HeaderText = "Tema"
        Me.Tema.Name = "Tema"
        Me.Tema.Width = 150
        '
        'Resumen
        '
        Me.Resumen.HeaderText = "Resúmen"
        Me.Resumen.Name = "Resumen"
        Me.Resumen.Width = 500
        '
        'Responsable
        '
        Me.Responsable.HeaderText = "Responsable"
        Me.Responsable.Name = "Responsable"
        '
        'Plazo
        '
        Me.Plazo.HeaderText = "Plazo"
        Me.Plazo.Name = "Plazo"
        '
        'Efectuado
        '
        Me.Efectuado.HeaderText = "Efectuado"
        Me.Efectuado.Name = "Efectuado"
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(12, 184)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(51, 20)
        Me.TextId.TabIndex = 16
        '
        'TextResumen
        '
        Me.TextResumen.Location = New System.Drawing.Point(232, 184)
        Me.TextResumen.Multiline = True
        Me.TextResumen.Name = "TextResumen"
        Me.TextResumen.Size = New System.Drawing.Size(325, 91)
        Me.TextResumen.TabIndex = 18
        '
        'TextResponsables
        '
        Me.TextResponsables.Location = New System.Drawing.Point(563, 184)
        Me.TextResponsables.Name = "TextResponsables"
        Me.TextResponsables.Size = New System.Drawing.Size(123, 20)
        Me.TextResponsables.TabIndex = 19
        '
        'CheckEfectuado
        '
        Me.CheckEfectuado.AutoSize = True
        Me.CheckEfectuado.Location = New System.Drawing.Point(809, 186)
        Me.CheckEfectuado.Name = "CheckEfectuado"
        Me.CheckEfectuado.Size = New System.Drawing.Size(75, 17)
        Me.CheckEfectuado.TabIndex = 21
        Me.CheckEfectuado.Text = "Efectuado"
        Me.CheckEfectuado.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 22
        Me.Button2.Text = "Nueva acta"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(93, 12)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 23
        Me.Button3.Text = "Buscar acta"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ButtonGuardarItem
        '
        Me.ButtonGuardarItem.Location = New System.Drawing.Point(890, 182)
        Me.ButtonGuardarItem.Name = "ButtonGuardarItem"
        Me.ButtonGuardarItem.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardarItem.TabIndex = 24
        Me.ButtonGuardarItem.Text = "Guardar ítem"
        Me.ButtonGuardarItem.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(25, 168)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(16, 13)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Id"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(94, 168)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 13)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Tema"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(229, 168)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 13)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Resúmen"
        '
        'TextLugar
        '
        Me.TextLugar.Location = New System.Drawing.Point(451, 80)
        Me.TextLugar.Name = "TextLugar"
        Me.TextLugar.Size = New System.Drawing.Size(121, 20)
        Me.TextLugar.TabIndex = 28
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(560, 168)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(74, 13)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "Responsables"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(692, 168)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(33, 13)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "Plazo"
        '
        'DatePlazo
        '
        Me.DatePlazo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DatePlazo.Location = New System.Drawing.Point(692, 182)
        Me.DatePlazo.Name = "DatePlazo"
        Me.DatePlazo.Size = New System.Drawing.Size(100, 20)
        Me.DatePlazo.TabIndex = 31
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(890, 211)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEliminar.TabIndex = 32
        Me.ButtonEliminar.Text = "Eliminar ítem"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'ComboTema
        '
        Me.ComboTema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboTema.FormattingEnabled = True
        Me.ComboTema.Items.AddRange(New Object() {"Calidad", "Documentación", "Equipamiento e insumos", "Eventos", "Lectura acta anterior", "Mantenimiento del sector", "Mejoras en Colaveco NET", "Operativa del laboratorio", "Proveedores", "Reclamos y no conformidades", "RRHH", "Seguimiento a socios/clientes", "Técnicas analíticas", "*** Sin asignar ***"})
        Me.ComboTema.Location = New System.Drawing.Point(69, 183)
        Me.ComboTema.Name = "ComboTema"
        Me.ComboTema.Size = New System.Drawing.Size(156, 21)
        Me.ComboTema.TabIndex = 33
        '
        'ComboTitular
        '
        Me.ComboTitular.FormattingEnabled = True
        Me.ComboTitular.Location = New System.Drawing.Point(605, 210)
        Me.ComboTitular.Name = "ComboTitular"
        Me.ComboTitular.Size = New System.Drawing.Size(175, 21)
        Me.ComboTitular.TabIndex = 34
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(563, 213)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(36, 13)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "Titular"
        '
        'ComboTitular2
        '
        Me.ComboTitular2.FormattingEnabled = True
        Me.ComboTitular2.Location = New System.Drawing.Point(605, 237)
        Me.ComboTitular2.Name = "ComboTitular2"
        Me.ComboTitular2.Size = New System.Drawing.Size(175, 21)
        Me.ComboTitular2.TabIndex = 36
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(563, 240)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(36, 13)
        Me.Label14.TabIndex = 37
        Me.Label14.Text = "Titular"
        '
        'ButtonImprimir
        '
        Me.ButtonImprimir.Location = New System.Drawing.Point(894, 547)
        Me.ButtonImprimir.Name = "ButtonImprimir"
        Me.ButtonImprimir.Size = New System.Drawing.Size(75, 23)
        Me.ButtonImprimir.TabIndex = 38
        Me.ButtonImprimir.Text = "Imprimir"
        Me.ButtonImprimir.UseVisualStyleBackColor = True
        '
        'FormActas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(981, 583)
        Me.Controls.Add(Me.ButtonImprimir)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.ComboTitular2)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.ComboTitular)
        Me.Controls.Add(Me.ComboTema)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.DatePlazo)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TextLugar)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ButtonGuardarItem)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.CheckEfectuado)
        Me.Controls.Add(Me.TextResponsables)
        Me.Controls.Add(Me.TextResumen)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ButtonGuardarActa)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextPresentes)
        Me.Controls.Add(Me.ComboGrupo)
        Me.Controls.Add(Me.TextHora)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.TextNumero)
        Me.Controls.Add(Me.TextIdActa)
        Me.Name = "FormActas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actas"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextIdActa As System.Windows.Forms.TextBox
    Friend WithEvents TextNumero As System.Windows.Forms.TextBox
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextHora As System.Windows.Forms.TextBox
    Friend WithEvents ComboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents TextPresentes As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ButtonGuardarActa As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents TextResumen As System.Windows.Forms.TextBox
    Friend WithEvents TextResponsables As System.Windows.Forms.TextBox
    Friend WithEvents CheckEfectuado As System.Windows.Forms.CheckBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardarItem As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextLugar As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents DatePlazo As System.Windows.Forms.DateTimePicker
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents ComboTema As System.Windows.Forms.ComboBox
    Friend WithEvents ComboTitular As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdActa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tema As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Resumen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Responsable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Plazo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Efectuado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComboTitular2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ButtonImprimir As System.Windows.Forms.Button
End Class
