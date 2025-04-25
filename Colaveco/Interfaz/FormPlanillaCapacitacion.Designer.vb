<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPlanillaCapacitacion
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
        Me.ComboParticipante = New System.Windows.Forms.ComboBox()
        Me.ComboTipoActividad = New System.Windows.Forms.ComboBox()
        Me.TextInstructor = New System.Windows.Forms.TextBox()
        Me.DateInicio = New System.Windows.Forms.DateTimePicker()
        Me.DateFin = New System.Windows.Forms.DateTimePicker()
        Me.TextLocal = New System.Windows.Forms.TextBox()
        Me.TextHoras = New System.Windows.Forms.TextBox()
        Me.TextCosto = New System.Windows.Forms.TextBox()
        Me.ComboAutorizacion = New System.Windows.Forms.ComboBox()
        Me.DateAutorizacion = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextId = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ComboB1 = New System.Windows.Forms.ComboBox()
        Me.ComboB2 = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.ComboB3 = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TextRecomendar = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TextComentarios = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.ComboEvaluacionDir = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TextIdLin = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.CbxEvaluacion = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ComboParticipante
        '
        Me.ComboParticipante.FormattingEnabled = True
        Me.ComboParticipante.Location = New System.Drawing.Point(103, 52)
        Me.ComboParticipante.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboParticipante.Name = "ComboParticipante"
        Me.ComboParticipante.Size = New System.Drawing.Size(237, 24)
        Me.ComboParticipante.TabIndex = 1
        '
        'ComboTipoActividad
        '
        Me.ComboTipoActividad.FormattingEnabled = True
        Me.ComboTipoActividad.Location = New System.Drawing.Point(353, 50)
        Me.ComboTipoActividad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboTipoActividad.Name = "ComboTipoActividad"
        Me.ComboTipoActividad.Size = New System.Drawing.Size(235, 24)
        Me.ComboTipoActividad.TabIndex = 2
        '
        'TextInstructor
        '
        Me.TextInstructor.Location = New System.Drawing.Point(33, 101)
        Me.TextInstructor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextInstructor.Name = "TextInstructor"
        Me.TextInstructor.Size = New System.Drawing.Size(307, 22)
        Me.TextInstructor.TabIndex = 3
        '
        'DateInicio
        '
        Me.DateInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateInicio.Location = New System.Drawing.Point(33, 151)
        Me.DateInicio.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DateInicio.Name = "DateInicio"
        Me.DateInicio.Size = New System.Drawing.Size(129, 22)
        Me.DateInicio.TabIndex = 5
        '
        'DateFin
        '
        Me.DateFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFin.Location = New System.Drawing.Point(172, 151)
        Me.DateFin.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DateFin.Name = "DateFin"
        Me.DateFin.Size = New System.Drawing.Size(129, 22)
        Me.DateFin.TabIndex = 6
        '
        'TextLocal
        '
        Me.TextLocal.Location = New System.Drawing.Point(349, 101)
        Me.TextLocal.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextLocal.Name = "TextLocal"
        Me.TextLocal.Size = New System.Drawing.Size(316, 22)
        Me.TextLocal.TabIndex = 4
        '
        'TextHoras
        '
        Me.TextHoras.Location = New System.Drawing.Point(311, 151)
        Me.TextHoras.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextHoras.Name = "TextHoras"
        Me.TextHoras.Size = New System.Drawing.Size(132, 22)
        Me.TextHoras.TabIndex = 7
        '
        'TextCosto
        '
        Me.TextCosto.Location = New System.Drawing.Point(452, 151)
        Me.TextCosto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextCosto.Name = "TextCosto"
        Me.TextCosto.Size = New System.Drawing.Size(132, 22)
        Me.TextCosto.TabIndex = 8
        '
        'ComboAutorizacion
        '
        Me.ComboAutorizacion.FormattingEnabled = True
        Me.ComboAutorizacion.Items.AddRange(New Object() {"Si", "No"})
        Me.ComboAutorizacion.Location = New System.Drawing.Point(37, 207)
        Me.ComboAutorizacion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboAutorizacion.Name = "ComboAutorizacion"
        Me.ComboAutorizacion.Size = New System.Drawing.Size(105, 24)
        Me.ComboAutorizacion.TabIndex = 9
        '
        'DateAutorizacion
        '
        Me.DateAutorizacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateAutorizacion.Location = New System.Drawing.Point(152, 208)
        Me.DateAutorizacion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DateAutorizacion.Name = "DateAutorizacion"
        Me.DateAutorizacion.Size = New System.Drawing.Size(129, 22)
        Me.DateAutorizacion.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(103, 32)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 17)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Participante"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(351, 31)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 17)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Tipo de actividad"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(29, 81)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(138, 17)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Institución/ Instructor"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(33, 132)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 17)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Fecha inicio"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(168, 132)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(121, 17)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Fecha finalización"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(345, 81)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 17)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Local"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(312, 132)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 17)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Horas de curso"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(448, 132)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 17)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Costo"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(33, 187)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(109, 17)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Autorización DT"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(152, 188)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(128, 17)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Fecha autorización"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(28, 32)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(19, 17)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Id"
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(32, 52)
        Me.TextId.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(61, 22)
        Me.TextId.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(28, 250)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(617, 17)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Sección B: EVALUACION DEL EVENTO POR EL PARTICIPANTE (Califique de 1 a 5 )"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(29, 318)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(569, 17)
        Me.Label14.TabIndex = 25
        Me.Label14.Text = "1) El contenido del curso/actividad: ¿aportó conocimientos teórico / prácticos de" & _
    " utilidad?"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(29, 358)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(225, 17)
        Me.Label15.TabIndex = 26
        Me.Label15.Text = "2) ¿cumplió con sus espectativas?"
        '
        'ComboB1
        '
        Me.ComboB1.FormattingEnabled = True
        Me.ComboB1.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        Me.ComboB1.Location = New System.Drawing.Point(611, 308)
        Me.ComboB1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboB1.Name = "ComboB1"
        Me.ComboB1.Size = New System.Drawing.Size(55, 24)
        Me.ComboB1.TabIndex = 11
        '
        'ComboB2
        '
        Me.ComboB2.FormattingEnabled = True
        Me.ComboB2.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        Me.ComboB2.Location = New System.Drawing.Point(264, 348)
        Me.ComboB2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboB2.Name = "ComboB2"
        Me.ComboB2.Size = New System.Drawing.Size(55, 24)
        Me.ComboB2.TabIndex = 12
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(29, 396)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(413, 17)
        Me.Label20.TabIndex = 37
        Me.Label20.Text = "3) ¿Recomendaría este curso/actividad para otros funcionarios?"
        '
        'ComboB3
        '
        Me.ComboB3.FormattingEnabled = True
        Me.ComboB3.Items.AddRange(New Object() {"Si", "No"})
        Me.ComboB3.Location = New System.Drawing.Point(453, 386)
        Me.ComboB3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboB3.Name = "ComboB3"
        Me.ComboB3.Size = New System.Drawing.Size(71, 24)
        Me.ComboB3.TabIndex = 13
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(29, 425)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(74, 17)
        Me.Label21.TabIndex = 39
        Me.Label21.Text = "¿Por que?"
        '
        'TextRecomendar
        '
        Me.TextRecomendar.Location = New System.Drawing.Point(33, 444)
        Me.TextRecomendar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextRecomendar.Multiline = True
        Me.TextRecomendar.Name = "TextRecomendar"
        Me.TextRecomendar.Size = New System.Drawing.Size(616, 56)
        Me.TextRecomendar.TabIndex = 14
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(28, 505)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(179, 17)
        Me.Label22.TabIndex = 41
        Me.Label22.Text = "4) Comentarios adicionales"
        '
        'TextComentarios
        '
        Me.TextComentarios.Location = New System.Drawing.Point(33, 524)
        Me.TextComentarios.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextComentarios.Multiline = True
        Me.TextComentarios.Name = "TextComentarios"
        Me.TextComentarios.Size = New System.Drawing.Size(616, 52)
        Me.TextComentarios.TabIndex = 15
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(28, 11)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(411, 17)
        Me.Label23.TabIndex = 44
        Me.Label23.Text = "Sección A: DATOS DEL EVENTO Y DEL PARTICIPANTE"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(753, 11)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(503, 17)
        Me.Label24.TabIndex = 45
        Me.Label24.Text = "Sección C: EVALUACIÓN DE LA CAPACITACIÓN POR LA DIRECCIÓN"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(32, 588)
        Me.Label29.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(432, 17)
        Me.Label29.TabIndex = 54
        Me.Label29.Text = "1) Evalución final del aprovechamiento del curso por el funcionario:"
        Me.Label29.Visible = False
        '
        'ComboEvaluacionDir
        '
        Me.ComboEvaluacionDir.FormattingEnabled = True
        Me.ComboEvaluacionDir.Location = New System.Drawing.Point(37, 608)
        Me.ComboEvaluacionDir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboEvaluacionDir.Name = "ComboEvaluacionDir"
        Me.ComboEvaluacionDir.Size = New System.Drawing.Size(448, 24)
        Me.ComboEvaluacionDir.TabIndex = 16
        Me.ComboEvaluacionDir.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1087, 585)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(100, 28)
        Me.Button2.TabIndex = 18
        Me.Button2.Text = "Guardar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(1195, 585)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(100, 28)
        Me.Button3.TabIndex = 20
        Me.Button3.Text = "Eliminar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TextIdLin
        '
        Me.TextIdLin.Location = New System.Drawing.Point(597, 50)
        Me.TextIdLin.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextIdLin.Name = "TextIdLin"
        Me.TextIdLin.Size = New System.Drawing.Size(72, 22)
        Me.TextIdLin.TabIndex = 61
        Me.TextIdLin.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(753, 50)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 17)
        Me.Label2.TabIndex = 70
        Me.Label2.Text = "Evaluación"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(484, 268)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(189, 17)
        Me.Label19.TabIndex = 74
        Me.Label19.Text = "1 = Malo -  5 = Excelente"
        '
        'CbxEvaluacion
        '
        Me.CbxEvaluacion.FormattingEnabled = True
        Me.CbxEvaluacion.Items.AddRange(New Object() {"Si", "No"})
        Me.CbxEvaluacion.Location = New System.Drawing.Point(969, 50)
        Me.CbxEvaluacion.Name = "CbxEvaluacion"
        Me.CbxEvaluacion.Size = New System.Drawing.Size(107, 24)
        Me.CbxEvaluacion.TabIndex = 75
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(756, 101)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(447, 17)
        Me.Label16.TabIndex = 76
        Me.Label16.Text = "la evaluación de eficiencia por direccion se encuentra en el doc.cc.17"
        '
        'FormPlanillaCapacitacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1331, 662)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.CbxEvaluacion)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextIdLin)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ComboEvaluacionDir)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.TextComentarios)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.TextRecomendar)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.ComboB3)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.ComboB2)
        Me.Controls.Add(Me.ComboB1)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateAutorizacion)
        Me.Controls.Add(Me.ComboAutorizacion)
        Me.Controls.Add(Me.TextCosto)
        Me.Controls.Add(Me.TextHoras)
        Me.Controls.Add(Me.TextLocal)
        Me.Controls.Add(Me.DateFin)
        Me.Controls.Add(Me.DateInicio)
        Me.Controls.Add(Me.TextInstructor)
        Me.Controls.Add(Me.ComboTipoActividad)
        Me.Controls.Add(Me.ComboParticipante)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FormPlanillaCapacitacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RG.ADM.19 v 02 - PLANILLA DE CAPACITACION Y EVALUACIÓN DE EVENTOS."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboParticipante As System.Windows.Forms.ComboBox
    Friend WithEvents ComboTipoActividad As System.Windows.Forms.ComboBox
    Friend WithEvents TextInstructor As System.Windows.Forms.TextBox
    Friend WithEvents DateInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextLocal As System.Windows.Forms.TextBox
    Friend WithEvents TextHoras As System.Windows.Forms.TextBox
    Friend WithEvents TextCosto As System.Windows.Forms.TextBox
    Friend WithEvents ComboAutorizacion As System.Windows.Forms.ComboBox
    Friend WithEvents DateAutorizacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ComboB1 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboB2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents ComboB3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TextRecomendar As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TextComentarios As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents ComboEvaluacionDir As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents TextIdLin As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents CbxEvaluacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
