Public Class pControlInformesSuelos
    Inherits Conectoras.ConexionMySQL


    Public Function guardar(ByVal o As Object) As Boolean
        Dim obj As dControlInformesSuelos = CType(o, dControlInformesSuelos)

        ' 1. Verificar si ya existe una ficha igual
        Dim sqlVerificar As String = "SELECT COUNT(*) FROM controlinformessuelos WHERE ficha = " & obj.FICHA
        Dim ds As DataSet = Me.EjecutarSQL(sqlVerificar)

        If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
            Dim cantidad As Integer = Convert.ToInt32(ds.Tables(0).Rows(0)(0))
            If cantidad > 0 Then

                Return False
            End If
        End If

        ' 2. Si no existe, se guarda el nuevo registro
        Dim sql As String = "INSERT INTO controlinformessuelos (id, fechacontrol, ficha, fecha, tipo, resultado, coincide, opcionmejora, noconformidad, observaciones, controlador, controlado) " &
                            "VALUES (" & obj.ID & ",'" & obj.FECHACONTROL & "'," & obj.FICHA & ", '" & obj.FECHA & "'," & obj.TIPO & ", " & obj.RESULTADO & "," & obj.COINCIDE & "," & obj.OM & "," & obj.NC & ",'" & obj.OBSERVACIONES & "'," & obj.CONTROLADOR & "," & obj.CONTROLADO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function

    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControlInformesSuelos = CType(o, dControlInformesSuelos)
        Dim sql As String = "UPDATE controlinformessuelos SET fechacontrol ='" & obj.FECHACONTROL & "',ficha=" & obj.FICHA & ",fecha ='" & obj.FECHA & "',tipo =" & obj.TIPO & ",resultado =" & obj.RESULTADO & ", coincide=" & obj.COINCIDE & ",opcionmejora=" & obj.OM & ",noconformidad=" & obj.NC & ",  observaciones ='" & obj.OBSERVACIONES & "', controlador =" & obj.CONTROLADOR & ",  controlado =" & obj.CONTROLADO & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'controlinformessuelos', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControlInformesSuelos = CType(o, dControlInformesSuelos)
        Dim sql As String = "DELETE FROM controlinformessuelos WHERE id = " & obj.ID & ""
        'Dim sql As String = "UPDATE controlinformessuelos SET eliminado =1 WHERE id = " & obj.ID
        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'controlinformessuelos', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dControlInformesSuelos
        Dim obj As dControlInformesSuelos = CType(o, dControlInformesSuelos)
        Dim c As New dControlInformesSuelos
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fechacontrol, ficha, fecha, tipo, resultado, coincide,opcionmejora, noconformidad, observaciones,  controlador, controlado FROM controlinformessuelos WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.FECHACONTROL = CType(unaFila.Item(1), String)
                c.FICHA = CType(unaFila.Item(2), Long)
                c.FECHA = CType(unaFila.Item(3), String)
                c.TIPO = CType(unaFila.Item(4), Integer)
                c.RESULTADO = CType(unaFila.Item(5), Integer)
                c.COINCIDE = CType(unaFila.Item(6), Integer)
                c.OM = CType(unaFila.Item(7), Integer)
                c.NC = CType(unaFila.Item(8), Integer)
                c.OBSERVACIONES = CType(unaFila.Item(9), String)
                c.CONTROLADOR = CType(unaFila.Item(10), Integer)
                c.CONTROLADO = CType(unaFila.Item(11), Integer)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxficha(ByVal o As Object) As dControlInformesSuelos
        Dim obj As dControlInformesSuelos = CType(o, dControlInformesSuelos)
        Dim c As New dControlInformesSuelos
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fechacontrol, ficha, fecha, tipo, resultado, coincide,opcionmejora, noconformidad, observaciones,  controlador, controlado FROM controlinformessuelos WHERE ficha = " & obj.FICHA & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.FECHACONTROL = CType(unaFila.Item(1), String)
                c.FICHA = CType(unaFila.Item(2), Long)
                c.FECHA = CType(unaFila.Item(3), String)
                c.TIPO = CType(unaFila.Item(4), Integer)
                c.RESULTADO = CType(unaFila.Item(5), Integer)
                c.COINCIDE = CType(unaFila.Item(6), Integer)
                c.OM = CType(unaFila.Item(7), Integer)
                c.NC = CType(unaFila.Item(8), Integer)
                c.OBSERVACIONES = CType(unaFila.Item(9), String)
                c.CONTROLADOR = CType(unaFila.Item(10), Integer)
                c.CONTROLADO = CType(unaFila.Item(11), Integer)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = ("select id, fechacontrol, ficha, fecha, tipo, resultado, coincide,opcionmejora, noconformidad, observaciones,  controlador, controlado FROM controlinformessuelos WHERE controlado = 0 order by fecha asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dControlInformesSuelos
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FECHACONTROL = CType(unaFila.Item(1), String)
                    c.FICHA = CType(unaFila.Item(2), Long)
                    c.FECHA = CType(unaFila.Item(3), String)
                    c.TIPO = CType(unaFila.Item(4), Integer)
                    c.RESULTADO = CType(unaFila.Item(5), Integer)
                    c.COINCIDE = CType(unaFila.Item(6), Integer)
                    c.OM = CType(unaFila.Item(7), Integer)
                    c.NC = CType(unaFila.Item(8), Integer)
                    c.OBSERVACIONES = CType(unaFila.Item(9), String)
                    c.CONTROLADOR = CType(unaFila.Item(10), Integer)
                    c.CONTROLADO = CType(unaFila.Item(11), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    'Public Function listarxfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
    '    Dim sql As String = ("select id, fechacontrol, ficha, fecha, tipo, resultado, coincide,opcionmejora, noconformidad, observaciones,  controlador, controlado FROM controlinformessuelos WHERE fecha >='" & desde & "' and fecha <='" & hasta & "' AND controlado = 1 order by tipo asc")
    '    Try
    '        Dim Lista As New ArrayList
    '        Dim Ds As New DataSet
    '        Ds = Me.EjecutarSQL(sql)
    '        If Ds.Tables(0).Rows.Count = 0 Then
    '            Return Nothing
    '        Else
    '            Dim unaFila As DataRow
    '            For Each unaFila In Ds.Tables(0).Rows
    '                Dim c As New dControlInformesSuelos
    '                c.ID = CType(unaFila.Item(0), Long)
    '                c.FECHACONTROL = CType(unaFila.Item(1), String)
    '                c.FICHA = CType(unaFila.Item(2), Long)
    '                c.FECHA = CType(unaFila.Item(3), String)
    '                c.TIPO = CType(unaFila.Item(4), Integer)
    '                c.RESULTADO = CType(unaFila.Item(5), Integer)
    '                c.COINCIDE = CType(unaFila.Item(6), Integer)
    '                c.OM = CType(unaFila.Item(7), Integer)
    '                c.NC = CType(unaFila.Item(8), Integer)
    '                c.OBSERVACIONES = CType(unaFila.Item(9), String)
    '                c.CONTROLADOR = CType(unaFila.Item(10), Integer)
    '                c.CONTROLADO = CType(unaFila.Item(11), Integer)
    '                Lista.Add(c)
    '            Next
    '            Return Lista
    '        End If
    '    Catch ex As Exception
    '        Return Nothing
    '    End Try
    'End Function

    Public Function listarxfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = _
            "SELECT m.id, m.fechacontrol, m.ficha, m.fecha, " & _
            "       m.tipo, ti.nombre AS tiponombre, " & _
            "       m.resultado, m.coincide, m.opcionmejora, m.noconformidad, " & _
            "       m.observaciones, m.controlador, m.controlado " & _
            "FROM controlinformessuelos m " & _
            "LEFT JOIN tipoinforme ti ON ti.id = m.tipo " & _
            "WHERE m.fecha >= '" & desde & "' AND m.fecha <= '" & hasta & "' " & _
            "  AND m.controlado = 1 " & _
            "ORDER BY m.tipo ASC"

        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)

            If Ds Is Nothing OrElse Ds.Tables.Count = 0 OrElse Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            End If

            For Each unaFila As DataRow In Ds.Tables(0).Rows
                Dim c As New dControlInformesSuelos
                c.ID = CType(unaFila.Item(0), Long)
                c.FECHACONTROL = CType(unaFila.Item(1), String)
                c.FICHA = CType(unaFila.Item(2), Long)
                c.FECHA = CType(unaFila.Item(3), String)

                ' OJO: ahora vienen "tipo" (ID) y "tiponombre" (texto)
                c.TIPO = CType(unaFila.Item(4), Integer)
                c.TIPONOMBRE = CType(unaFila.Item(5), String)

                c.RESULTADO = CType(unaFila.Item(6), Integer)
                c.COINCIDE = CType(unaFila.Item(7), Integer)
                c.OM = CType(unaFila.Item(8), Integer)
                c.NC = CType(unaFila.Item(9), Integer)
                c.OBSERVACIONES = CType(unaFila.Item(10), String)
                c.CONTROLADOR = CType(unaFila.Item(11), Integer)
                c.CONTROLADO = CType(unaFila.Item(12), Integer)

                Lista.Add(c)
            Next

            Return Lista
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarxtipoxfecha(ByVal tipo As Integer, ByVal desde As String, ByVal hasta As String, ByVal ficha As Long) As ArrayList
        Dim sql As String = "SELECT id, fechacontrol, ficha, fecha, tipo, resultado, coincide, opcionmejora, noconformidad, observaciones, controlador, controlado " &
                            "FROM controlinformessuelos " &
                            "WHERE tipo = " & tipo & " AND fecha >= '" & desde & "' AND fecha <= '" & hasta & "' " &
                            "AND ficha <> " & ficha

        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                For Each unaFila As DataRow In Ds.Tables(0).Rows
                    Dim c As New dControlInformesSuelos
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FECHACONTROL = CType(unaFila.Item(1), String)
                    c.FICHA = CType(unaFila.Item(2), Long)
                    c.FECHA = CType(unaFila.Item(3), String)
                    c.TIPO = CType(unaFila.Item(4), Integer)
                    c.RESULTADO = CType(unaFila.Item(5), Integer)
                    c.COINCIDE = CType(unaFila.Item(6), Integer)
                    c.OM = CType(unaFila.Item(7), Integer)
                    c.NC = CType(unaFila.Item(8), Integer)
                    c.OBSERVACIONES = CType(unaFila.Item(9), String)
                    c.CONTROLADOR = CType(unaFila.Item(10), Integer)
                    c.CONTROLADO = CType(unaFila.Item(11), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function listarxfechanc(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("select id, fechacontrol, ficha, fecha, tipo, resultado, coincide,opcionmejora, noconformidad, observaciones,  controlador, controlado FROM controlinformessuelos WHERE fecha >='" & desde & "' and fecha <='" & hasta & "' AND controlado = 1 AND noconformidad=1 order by tipo asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dControlInformesSuelos
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FECHACONTROL = CType(unaFila.Item(1), String)
                    c.FICHA = CType(unaFila.Item(2), Long)
                    c.FECHA = CType(unaFila.Item(3), String)
                    c.TIPO = CType(unaFila.Item(4), Integer)
                    c.RESULTADO = CType(unaFila.Item(5), Integer)
                    c.COINCIDE = CType(unaFila.Item(6), Integer)
                    c.OM = CType(unaFila.Item(7), Integer)
                    c.NC = CType(unaFila.Item(8), Integer)
                    c.OBSERVACIONES = CType(unaFila.Item(9), String)
                    c.CONTROLADOR = CType(unaFila.Item(10), Integer)
                    c.CONTROLADO = CType(unaFila.Item(11), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxfechaom(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = ("select id, fechacontrol, ficha, fecha, tipo, resultado, coincide,opcionmejora, noconformidad, observaciones,  controlador, controlado FROM controlinformessuelos WHERE fecha >='" & desde & "' and fecha <='" & hasta & "' AND controlado = 1 AND opcionmejora=1 order by tipo asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dControlInformesSuelos
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FECHACONTROL = CType(unaFila.Item(1), String)
                    c.FICHA = CType(unaFila.Item(2), Long)
                    c.FECHA = CType(unaFila.Item(3), String)
                    c.TIPO = CType(unaFila.Item(4), Integer)
                    c.RESULTADO = CType(unaFila.Item(5), Integer)
                    c.COINCIDE = CType(unaFila.Item(6), Integer)
                    c.OM = CType(unaFila.Item(7), Integer)
                    c.NC = CType(unaFila.Item(8), Integer)
                    c.OBSERVACIONES = CType(unaFila.Item(9), String)
                    c.CONTROLADOR = CType(unaFila.Item(10), Integer)
                    c.CONTROLADO = CType(unaFila.Item(11), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function marcarresultado(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControlInformesSuelos = CType(o, dControlInformesSuelos)
        Dim sql As String = "UPDATE controlinformessuelos SET resultado=1 WHERE resultado=0 and ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function desmarcarresultado(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControlInformesSuelos = CType(o, dControlInformesSuelos)
        Dim sql As String = "UPDATE controlinformessuelos SET resultado=0 WHERE resultado=1 and ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarcoincide(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControlInformesSuelos = CType(o, dControlInformesSuelos)
        Dim sql As String = "UPDATE controlinformessuelos SET coincide=1 WHERE coincide=0 and ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function desmarcarcoincide(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControlInformesSuelos = CType(o, dControlInformesSuelos)
        Dim sql As String = "UPDATE controlinformessuelos SET coincide=0 WHERE coincide=1 and ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarom(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControlInformesSuelos = CType(o, dControlInformesSuelos)
        Dim sql As String = "UPDATE controlinformessuelos SET opcionmejora=1 WHERE opcionmejora=0 and ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function desmarcarom(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControlInformesSuelos = CType(o, dControlInformesSuelos)
        Dim sql As String = "UPDATE controlinformessuelos SET opcionmejora=0 WHERE opcionmejora=1 and ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarnc(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControlInformesSuelos = CType(o, dControlInformesSuelos)
        Dim sql As String = "UPDATE controlinformessuelos SET noconformidad=1 WHERE noconformidad=0 and ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function desmarcarnc(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControlInformesSuelos = CType(o, dControlInformesSuelos)
        Dim sql As String = "UPDATE controlinformessuelos SET noconformidad=0 WHERE noconformidad=1 and ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function

    Public Function marcarcontrolada(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControlInformesSuelos = CType(o, dControlInformesSuelos)
        Dim sql As String = "UPDATE controlinformessuelos SET controlado=1, controlador = " & usuario.ID & " WHERE controlado=0 and ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function guardarobservaciones(ByVal o As Object, ByVal usuario As dUsuario, ByVal obs As String) As Boolean
        Dim obj As dControlInformesSuelos = CType(o, dControlInformesSuelos)
        Dim sql As String = "UPDATE controlinformessuelos SET observaciones='" & obs & "' WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function lstConNom(ByVal ficha As Long) As dControlBase
        Dim sql As String = "SELECT u.nombre AS controlador_nombre, " &
                            "       CASE WHEN ci.controlado = 1 THEN 'SI' ELSE 'NO' END AS controlado " &
                            "FROM controlinformessuelos ci " &
                            "INNER JOIN usuario u ON u.id = ci.controlador " &
                            "WHERE ci.ficha = " & ficha

        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            Dim c As New dControlInformesNutricion
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                For Each unaFila As DataRow In Ds.Tables(0).Rows

                    ' Ahora CONTROLADOR va a tener el nombre
                    c.CONTROLADOR = CType(unaFila.Item("controlador_nombre"), String)
                    ' Y CONTROLADO va a ser "SI"/"NO"
                    c.CONTROLADOTECNICO = CType(unaFila.Item("controlado"), String)

                Next
                Return c
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
