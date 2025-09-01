Public Class pControldeInformes
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControldeInformes = CType(o, dControldeInformes)
        Dim sql As String = "INSERT INTO controldeinformes (id, fechacontrol, ficha, fecha, muestra, tipo, subtipo, resultado, coincide, opcionmejora, noconformidad, observaciones,  controlador, controlado) VALUES (" & obj.ID & ",'" & obj.FECHACONTROL & "'," & obj.FICHA & ", '" & obj.FECHA & "'," & obj.MUESTRA & "," & obj.TIPO & "," & obj.SUBTIPO & ", " & obj.RESULTADO & "," & obj.COINCIDE & "," & obj.OM & "," & obj.NC & ",'" & obj.OBSERVACIONES & "'," & obj.CONTROLADOR & "," & obj.CONTROLADO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'controldeinformes', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControldeInformes = CType(o, dControldeInformes)
        Dim sql As String = "UPDATE controldeinformes SET fechacontrol ='" & obj.FECHACONTROL & "',ficha=" & obj.FICHA & ",fecha ='" & obj.FECHA & "',muestra =" & obj.MUESTRA & ",tipo =" & obj.TIPO & ",subtipo =" & obj.SUBTIPO & ",resultado =" & obj.RESULTADO & ", coincide=" & obj.COINCIDE & ",opcionmejora=" & obj.OM & ",noconformidad=" & obj.NC & ",  observaciones ='" & obj.OBSERVACIONES & "', controlador =" & obj.CONTROLADOR & ",  controlado =" & obj.CONTROLADO & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'controldeinformes', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControldeInformes = CType(o, dControldeInformes)
        Dim sql As String = "DELETE FROM controldeinformes WHERE id = " & obj.ID & ""
        'Dim sql As String = "UPDATE controldeinformes SET eliminado =1 WHERE id = " & obj.ID
        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'controldeinformes', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dControldeInformes
        Dim obj As dControldeInformes = CType(o, dControldeInformes)
        Dim c As New dControldeInformes
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fechacontrol, ficha, fecha, muestra, tipo, subtipo, resultado, coincide,opcionmejora, noconformidad, observaciones,  controlador, controlado FROM controldeinformes WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.FECHACONTROL = CType(unaFila.Item(1), String)
                c.FICHA = CType(unaFila.Item(2), Long)
                c.FECHA = CType(unaFila.Item(3), String)
                c.MUESTRA = CType(unaFila.Item(4), Integer)
                c.TIPO = CType(unaFila.Item(5), Integer)
                c.SUBTIPO = CType(unaFila.Item(6), Integer)
                c.RESULTADO = CType(unaFila.Item(7), Integer)
                c.COINCIDE = CType(unaFila.Item(8), Integer)
                c.OM = CType(unaFila.Item(9), Integer)
                c.NC = CType(unaFila.Item(10), Integer)
                c.OBSERVACIONES = CType(unaFila.Item(11), String)
                c.CONTROLADOR = CType(unaFila.Item(12), Integer)
                c.CONTROLADO = CType(unaFila.Item(13), Integer)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = ("select id, fechacontrol, ficha, fecha, muestra, tipo, subtipo, resultado, coincide,opcionmejora, noconformidad, observaciones,  controlador, controlado FROM controldeinformes WHERE controlado = 0 order by fecha asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dControldeInformes
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FECHACONTROL = CType(unaFila.Item(1), String)
                    c.FICHA = CType(unaFila.Item(2), Long)
                    c.FECHA = CType(unaFila.Item(3), String)
                    c.MUESTRA = CType(unaFila.Item(4), Integer)
                    c.TIPO = CType(unaFila.Item(5), Integer)
                    c.SUBTIPO = CType(unaFila.Item(6), Integer)
                    c.RESULTADO = CType(unaFila.Item(7), Integer)
                    c.COINCIDE = CType(unaFila.Item(8), Integer)
                    c.OM = CType(unaFila.Item(9), Integer)
                    c.NC = CType(unaFila.Item(10), Integer)
                    c.OBSERVACIONES = CType(unaFila.Item(11), String)
                    c.CONTROLADOR = CType(unaFila.Item(12), Integer)
                    c.CONTROLADO = CType(unaFila.Item(13), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarPorFicha(ByVal ficha As Integer) As ArrayList
        Dim sql As String = ("select id, fechacontrol, ficha, fecha, muestra, tipo, subtipo, resultado, coincide,opcionmejora, noconformidad, observaciones,  controlador, controlado FROM controldeinformes WHERE FICHA = " & ficha & " and controlado = 0 order by fecha asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dControldeInformes
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FECHACONTROL = CType(unaFila.Item(1), String)
                    c.FICHA = CType(unaFila.Item(2), Long)
                    c.FECHA = CType(unaFila.Item(3), String)
                    c.MUESTRA = CType(unaFila.Item(4), Integer)
                    c.TIPO = CType(unaFila.Item(5), Integer)
                    c.SUBTIPO = CType(unaFila.Item(6), Integer)
                    c.RESULTADO = CType(unaFila.Item(7), Integer)
                    c.COINCIDE = CType(unaFila.Item(8), Integer)
                    c.OM = CType(unaFila.Item(9), Integer)
                    c.NC = CType(unaFila.Item(10), Integer)
                    c.OBSERVACIONES = CType(unaFila.Item(11), String)
                    c.CONTROLADOR = CType(unaFila.Item(12), Integer)
                    c.CONTROLADO = CType(unaFila.Item(13), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("select id, fechacontrol, ficha, fecha, muestra, tipo, subtipo, resultado, coincide,opcionmejora, noconformidad, observaciones,  controlador, controlado FROM controldeinformes WHERE fechacontrol >='" & desde & "' and fechacontrol <='" & hasta & "' AND controlado = 1 order by tipo asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dControldeInformes
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FECHACONTROL = CType(unaFila.Item(1), String)
                    c.FICHA = CType(unaFila.Item(2), Long)
                    c.FECHA = CType(unaFila.Item(3), String)
                    c.MUESTRA = CType(unaFila.Item(4), Integer)
                    c.TIPO = CType(unaFila.Item(5), Integer)
                    c.SUBTIPO = CType(unaFila.Item(6), Integer)
                    c.RESULTADO = CType(unaFila.Item(7), Integer)
                    c.COINCIDE = CType(unaFila.Item(8), Integer)
                    c.OM = CType(unaFila.Item(9), Integer)
                    c.NC = CType(unaFila.Item(10), Integer)
                    c.OBSERVACIONES = CType(unaFila.Item(11), String)
                    c.CONTROLADOR = CType(unaFila.Item(12), Integer)
                    c.CONTROLADO = CType(unaFila.Item(13), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxfechanc(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("select id, fechacontrol, ficha, fecha, muestra, tipo, subtipo, resultado, coincide,opcionmejora, noconformidad, observaciones,  controlador, controlado FROM controldeinformes WHERE fecha >='" & desde & "' and fecha <='" & hasta & "' AND controlado = 1 AND noconformidad=1 order by tipo asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dControldeInformes
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FECHACONTROL = CType(unaFila.Item(1), String)
                    c.FICHA = CType(unaFila.Item(2), Long)
                    c.FECHA = CType(unaFila.Item(3), String)
                    c.MUESTRA = CType(unaFila.Item(4), Integer)
                    c.TIPO = CType(unaFila.Item(5), Integer)
                    c.SUBTIPO = CType(unaFila.Item(6), Integer)
                    c.RESULTADO = CType(unaFila.Item(7), Integer)
                    c.COINCIDE = CType(unaFila.Item(8), Integer)
                    c.OM = CType(unaFila.Item(9), Integer)
                    c.NC = CType(unaFila.Item(10), Integer)
                    c.OBSERVACIONES = CType(unaFila.Item(11), String)
                    c.CONTROLADOR = CType(unaFila.Item(12), Integer)
                    c.CONTROLADO = CType(unaFila.Item(13), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxfechaom(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("select id, fechacontrol, ficha, fecha, muestra, tipo, subtipo, resultado, coincide,opcionmejora, noconformidad, observaciones,  controlador, controlado FROM controldeinformes WHERE fecha >='" & desde & "' and fecha <='" & hasta & "' AND controlado = 1 AND opcionmejora=1 order by tipo asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dControldeInformes
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FECHACONTROL = CType(unaFila.Item(1), String)
                    c.FICHA = CType(unaFila.Item(2), Long)
                    c.FECHA = CType(unaFila.Item(3), String)
                    c.MUESTRA = CType(unaFila.Item(4), Integer)
                    c.TIPO = CType(unaFila.Item(5), Integer)
                    c.SUBTIPO = CType(unaFila.Item(6), Integer)
                    c.RESULTADO = CType(unaFila.Item(7), Integer)
                    c.COINCIDE = CType(unaFila.Item(8), Integer)
                    c.OM = CType(unaFila.Item(9), Integer)
                    c.NC = CType(unaFila.Item(10), Integer)
                    c.OBSERVACIONES = CType(unaFila.Item(11), String)
                    c.CONTROLADOR = CType(unaFila.Item(12), Integer)
                    c.CONTROLADO = CType(unaFila.Item(13), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function marcarresultado(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControldeInformes = CType(o, dControldeInformes)
        Dim sql As String = "UPDATE controldeinformes SET resultado=1 WHERE resultado=0 and ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function desmarcarresultado(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControldeInformes = CType(o, dControldeInformes)
        Dim sql As String = "UPDATE controldeinformes SET resultado=0 WHERE resultado=1 and ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarcoincide(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControldeInformes = CType(o, dControldeInformes)
        Dim sql As String = "UPDATE controldeinformes SET coincide=1 WHERE coincide=0 and ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function desmarcarcoincide(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControldeInformes = CType(o, dControldeInformes)
        Dim sql As String = "UPDATE controldeinformes SET coincide=0 WHERE coincide=1 and ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarom(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControldeInformes = CType(o, dControldeInformes)
        Dim sql As String = "UPDATE controldeinformes SET opcionmejora=1 WHERE opcionmejora=0 and ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function desmarcarom(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControldeInformes = CType(o, dControldeInformes)
        Dim sql As String = "UPDATE controldeinformes SET opcionmejora=0 WHERE opcionmejora=1 and ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarnc(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControldeInformes = CType(o, dControldeInformes)
        Dim sql As String = "UPDATE controldeinformes SET noconformidad=1 WHERE noconformidad=0 and ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function desmarcarnc(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControldeInformes = CType(o, dControldeInformes)
        Dim sql As String = "UPDATE controldeinformes SET noconformidad=0 WHERE noconformidad=1 and ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function

    Public Function marcarcontrolada(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControldeInformes = CType(o, dControldeInformes)
        Dim sql As String = "UPDATE controldeinformes SET controlado=1 , fechacontrol = '" & obj.FECHACONTROL & "' WHERE controlado=0 and ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function guardarobservaciones(ByVal o As Object, ByVal usuario As dUsuario, ByVal obs As String) As Boolean
        Dim obj As dControldeInformes = CType(o, dControldeInformes)
        Dim sql As String = "UPDATE controldeinformes SET observaciones='" & obs & "' WHERE ficha = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function

    'Public Function listarIngenieria_Grilla(ByVal fechad As String, ByVal fechah As String, ByVal tipoinforme As Integer, ByVal controlador As Integer) As DataTable
    '    ' --- Normalización de fechas (último mes por defecto) ---
    '    Dim hasDesde As Boolean = Not String.IsNullOrEmpty(fechad)
    '    Dim hasHasta As Boolean = Not String.IsNullOrEmpty(fechah)
    '    Dim d As Date, h As Date
    '    If hasDesde AndAlso Date.TryParse(fechad, d) AndAlso hasHasta AndAlso Date.TryParse(fechah, h) Then
    '        ' ok
    '    ElseIf hasDesde AndAlso Date.TryParse(fechad, d) Then
    '        h = Date.Today
    '    ElseIf hasHasta AndAlso Date.TryParse(fechah, h) Then
    '        d = h.AddMonths(-1)
    '    Else
    '        h = Date.Today : d = h.AddMonths(-1)
    '    End If
    '    If d > h Then Dim tmp As Date = d : d = h : h = tmp

    '    Dim condFecha As String = " AND c.fecha >= '" & d.ToString("yyyy-MM-dd") & "' AND c.fecha <= '" & h.ToString("yyyy-MM-dd") & "'"
    '    Dim condTipo As String = If(tipoinforme > 0, " AND c.tipo = " & tipoinforme, "")
    '    Dim condCtrl As String = If(controlador > 0, " AND c.controlador = " & controlador, "")

    '    Dim tablas() As String = {"controlinformesefluentes", "controlinformesfq", "controlinformesmicro", "controlinformesnutricion", "controlinformessuelos"}

    '    Dim sb As New System.Text.StringBuilder()
    '    sb.AppendLine("SELECT")
    '    sb.AppendLine("  di.id,")
    '    sb.AppendLine("  di.fechacontrol,")
    '    sb.AppendLine("  di.ficha,")
    '    sb.AppendLine("  di.fecha,")
    '    sb.AppendLine("  COALESCE(lp.descripcion,'') AS muestra,")   ' nombre de muestra
    '    sb.AppendLine("  COALESCE(ti.nombre,'')      AS tipo,")     ' nombre de tipo
    '    sb.AppendLine("  di.resultado,")
    '    sb.AppendLine("  di.coincide,")
    '    sb.AppendLine("  di.opcionmejora,")
    '    sb.AppendLine("  di.noconformidad,")
    '    sb.AppendLine("  di.observaciones,")
    '    sb.AppendLine("  t.tecnico_nombre            AS TecnicoNombre,")
    '    sb.AppendLine("  'SI'                        AS InformeControlado")
    '    sb.AppendLine("FROM controldeinformes di")
    '    sb.AppendLine("LEFT JOIN listadeprecios lp ON lp.id = di.muestra")
    '    sb.AppendLine("LEFT JOIN tipoinforme   ti ON ti.id = di.tipo")
    '    sb.AppendLine("INNER JOIN (")
    '    sb.AppendLine("  SELECT ficha, tipo, MAX(COALESCE(tecnico,'')) AS tecnico_nombre")
    '    sb.AppendLine("  FROM (")

    '    For i As Integer = 0 To tablas.Length - 1
    '        Dim sel As String =
    '            "SELECT c.ficha, c.tipo, u.nombre AS tecnico " &
    '            "FROM " & tablas(i) & " c " &
    '            "INNER JOIN solicitudanalisis s ON s.id = c.ficha AND s.marca = 1 " &
    '            "LEFT JOIN usuario u ON u.id = c.controlador " &
    '            "WHERE c.controlado = 1" & condFecha & condTipo & condCtrl
    '        If i = 0 Then
    '            sb.AppendLine("    " & sel)
    '        Else
    '            sb.AppendLine("    UNION ALL " & sel)
    '        End If
    '    Next

    '    sb.AppendLine("  ) u")
    '    sb.AppendLine("  GROUP BY ficha, tipo")
    '    sb.AppendLine(") t ON t.ficha = di.ficha AND t.tipo = di.tipo")
    '    sb.AppendLine("WHERE di.controlado = 0")  ' pendientes del ingeniero (ajustá si querés 1 o todos)
    '    sb.AppendLine("ORDER BY ti.nombre ASC, di.fecha ASC")

    '    ' --- Ejecutar con tu helper y devolver DataTable ---
    '    Dim Ds As DataSet = Me.EjecutarSQL(sb.ToString())
    '    If Ds Is Nothing OrElse Ds.Tables.Count = 0 Then
    '        Return New DataTable()
    '    End If
    '    Return Ds.Tables(0)
    'End Function

    'Public Function listarIngenieria_Grilla(ByVal fechad As String, ByVal fechah As String, ByVal tipoinforme As Integer, ByVal controlador As Integer) As DataTable
    '    ' --- Normalización de fechas (último mes por defecto) ---
    '    Dim hasDesde As Boolean = Not String.IsNullOrEmpty(fechad)
    '    Dim hasHasta As Boolean = Not String.IsNullOrEmpty(fechah)
    '    Dim d As Date, h As Date
    '    If hasDesde AndAlso Date.TryParse(fechad, d) AndAlso hasHasta AndAlso Date.TryParse(fechah, h) Then
    '        ' ok
    '    ElseIf hasDesde AndAlso Date.TryParse(fechad, d) Then
    '        h = Date.Today
    '    ElseIf hasHasta AndAlso Date.TryParse(fechah, h) Then
    '        d = h.AddMonths(-1)
    '    Else
    '        h = Date.Today : d = h.AddMonths(-1)
    '    End If
    '    If d > h Then Dim tmp As Date = d : d = h : h = tmp

    '    ' Filtros (¡todos sobre alias c = tablas técnicas!)
    '    Dim condFecha As String = " AND c.fecha >= '" & d.ToString("yyyy-MM-dd") & "' AND c.fecha <= '" & h.ToString("yyyy-MM-dd") & "'"
    '    Dim condTipo As String = If(tipoinforme > 0, " AND c.tipo = " & tipoinforme, "")
    '    Dim condCtrl As String = If(controlador > 0, " AND c.controlador = " & controlador, "") ' ← SOLO en c

    '    Dim tablas() As String = {"controlinformesefluentes", "controlinformesfq", "controlinformesmicro", "controlinformesnutricion", "controlinformessuelos"}

    '    Dim sb As New System.Text.StringBuilder()
    '    sb.AppendLine("SELECT")
    '    sb.AppendLine("  di.id,")
    '    sb.AppendLine("  di.fechacontrol,")
    '    sb.AppendLine("  di.ficha,")
    '    sb.AppendLine("  di.fecha,")
    '    sb.AppendLine("  COALESCE(lp.descripcion,'') AS muestra,")   ' nombre de muestra
    '    sb.AppendLine("  COALESCE(ti.nombre,'')      AS tipo,")     ' nombre de tipo
    '    sb.AppendLine("  di.resultado,")
    '    sb.AppendLine("  di.coincide,")
    '    sb.AppendLine("  di.opcionmejora,")
    '    sb.AppendLine("  di.noconformidad,")
    '    sb.AppendLine("  di.observaciones,")
    '    sb.AppendLine("  t.tecnico_nombre            AS TecnicoNombre,")
    '    sb.AppendLine("  'SI'                        AS InformeControlado")
    '    sb.AppendLine("FROM controldeinformes di")
    '    sb.AppendLine("LEFT JOIN listadeprecios lp ON lp.id = di.muestra")
    '    sb.AppendLine("LEFT JOIN tipoinforme   ti ON ti.id = di.tipo")
    '    sb.AppendLine("INNER JOIN (")
    '    sb.AppendLine("  SELECT ficha, tipo, MAX(COALESCE(tecnico,'')) AS tecnico_nombre")
    '    sb.AppendLine("  FROM (")

    '    For i As Integer = 0 To tablas.Length - 1
    '        Dim sel As String =
    '            "SELECT c.ficha, c.tipo, u.nombre AS tecnico " &
    '            "FROM " & tablas(i) & " c " &
    '            "INNER JOIN solicitudanalisis s ON s.id = c.ficha AND s.marca = 1 " &
    '            "LEFT JOIN usuario u ON u.id = c.controlador " &
    '            "WHERE c.controlado = 1" & condFecha & condTipo & condCtrl   ' ← controlador aplicado acá
    '        If i = 0 Then
    '            sb.AppendLine("    " & sel)
    '        Else
    '            sb.AppendLine("    UNION ALL " & sel)
    '        End If
    '    Next

    '    sb.AppendLine("  ) u")
    '    sb.AppendLine("  GROUP BY ficha, tipo")
    '    sb.AppendLine(") t ON t.ficha = di.ficha AND t.tipo = di.tipo")
    '    sb.AppendLine("WHERE di.controlado = 0")  ' pendientes del ingeniero (NO filtramos por di.controlador)
    '    sb.AppendLine("ORDER BY ti.nombre ASC, di.fecha ASC")

    '    Dim Ds As DataSet = Me.EjecutarSQL(sb.ToString())
    '    If Ds Is Nothing OrElse Ds.Tables.Count = 0 Then
    '        Return New DataTable()
    '    End If
    '    Return Ds.Tables(0)
    'End Function

    Public Function listarIngenieria_Grilla(ByVal fechad As String, ByVal fechah As String, ByVal tipoinforme As Integer, ByVal controlador As Integer) As DataTable
        ' --- Normalización de fechas (último mes por defecto) ---
        Dim hasDesde As Boolean = Not String.IsNullOrEmpty(fechad)
        Dim hasHasta As Boolean = Not String.IsNullOrEmpty(fechah)
        Dim d As Date, h As Date
        If hasDesde AndAlso Date.TryParse(fechad, d) AndAlso hasHasta AndAlso Date.TryParse(fechah, h) Then
            ' ok
        ElseIf hasDesde AndAlso Date.TryParse(fechad, d) Then
            h = Date.Today
        ElseIf hasHasta AndAlso Date.TryParse(fechah, h) Then
            d = h.AddMonths(-1)
        Else
            h = Date.Today : d = h.AddMonths(-1)
        End If
        If d > h Then Dim tmp As Date = d : d = h : h = tmp

        ' Filtros (todos sobre alias c = tablas técnicas)
        Dim condFecha As String = " AND c.fecha >= '" & d.ToString("yyyy-MM-dd") & "' AND c.fecha <= '" & h.ToString("yyyy-MM-dd") & "'"
        Dim condTipo As String = If(tipoinforme > 0, " AND c.tipo = " & tipoinforme, "")
        Dim condCtrl As String = If(controlador > 0, " AND c.controlador = " & controlador, "")

        Dim tablas() As String = {"controlinformesefluentes", "controlinformesfq", "controlinformesmicro", "controlinformesnutricion", "controlinformessuelos"}

        Dim sb As New System.Text.StringBuilder()
        sb.AppendLine("SELECT")
        sb.AppendLine("  di.id,")
        sb.AppendLine("  di.fechacontrol,")
        sb.AppendLine("  di.ficha,")
        sb.AppendLine("  di.fecha,")
        sb.AppendLine("  COALESCE(lp.descripcion,'') AS muestra,")   ' nombre de muestra
        sb.AppendLine("  COALESCE(ti.nombre,'')      AS tipo,")     ' nombre de tipo
        sb.AppendLine("  di.resultado,")
        sb.AppendLine("  di.coincide,")
        sb.AppendLine("  di.opcionmejora,")
        sb.AppendLine("  di.noconformidad,")
        sb.AppendLine("  di.observaciones,")
        sb.AppendLine("  t.tecnico_nombre            AS TecnicoNombre,")
        sb.AppendLine("  CASE WHEN t.ctrl_flag = 1 THEN 'SI' ELSE 'NO' END AS InformeControlado")
        sb.AppendLine("FROM controldeinformes di")
        sb.AppendLine("LEFT JOIN listadeprecios lp ON lp.id = di.muestra")
        sb.AppendLine("LEFT JOIN tipoinforme   ti ON ti.id = di.tipo")
        sb.AppendLine("INNER JOIN (")
        sb.AppendLine("  SELECT ficha, tipo,")
        sb.AppendLine("         MAX(ctrl_flag) AS ctrl_flag,")
        sb.AppendLine("         MAX(COALESCE(tecnico,'')) AS tecnico_nombre")
        sb.AppendLine("  FROM (")

        For i As Integer = 0 To tablas.Length - 1
            Dim sel As String =
                "SELECT c.ficha, c.tipo, c.controlado AS ctrl_flag, COALESCE(u.nombre,'') AS tecnico " &
                "FROM " & tablas(i) & " c " &
                "INNER JOIN solicitudanalisis s ON s.id = c.ficha AND s.marca = 1 " &
                "LEFT JOIN usuario u ON u.id = c.controlador " &
                "WHERE 1=1" & condFecha & condTipo & condCtrl   ' ← ya no filtramos por c.controlado=1
            If i = 0 Then
                sb.AppendLine("    " & sel)
            Else
                sb.AppendLine("    UNION ALL " & sel)
            End If
        Next

        sb.AppendLine("  ) u")
        sb.AppendLine("  GROUP BY ficha, tipo")
        sb.AppendLine(") t ON t.ficha = di.ficha AND t.tipo = di.tipo")
        sb.AppendLine("WHERE di.controlado = 0")  ' pendientes del ingeniero
        sb.AppendLine("ORDER BY ti.nombre ASC, di.fecha ASC")

        Dim Ds As DataSet = Me.EjecutarSQL(sb.ToString())
        If Ds Is Nothing OrElse Ds.Tables.Count = 0 Then
            Return New DataTable()
        End If
        Return Ds.Tables(0)
    End Function






    End Class
