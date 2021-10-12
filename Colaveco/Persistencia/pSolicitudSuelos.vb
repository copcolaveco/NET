Public Class pSolicitudSuelos
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolicitudSuelos = CType(o, dSolicitudSuelos)
        Dim sql As String = "INSERT INTO solicitud_suelos (id, ficha, muestra, paquete, nitratos, mineralizacion, fosforobray, fosforocitrico, phagua, phkci, materiaorg, potasioint, sulfatos, nitrogenovegetal, calcio, magnesio, sodio, acideztitulable, cic, sb, muestreo, zinc, isusaestandar, isusazinc) VALUES (" & obj.ID & ", " & obj.FICHA & ",'" & obj.MUESTRA & "'," & obj.PAQUETE & "," & obj.NITRATOS & ", " & obj.MINERALIZACION & ", " & obj.FOSFOROBRAY & "," & obj.FOSFOROCITRICO & ", " & obj.PHAGUA & ", " & obj.PHKCI & "," & obj.MATERIAORG & ", " & obj.POTASIOINT & ", " & obj.SULFATOS & ", " & obj.NITROGENOVEGETAL & "," & obj.CALCIO & "," & obj.MAGNESIO & "," & obj.SODIO & "," & obj.ACIDEZTITULABLE & "," & obj.CIC & "," & obj.SB & "," & obj.MUESTREO & "," & obj.ZINC & "," & obj.ISUSAESTANDAR & "," & obj.ISUSAZINC & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitud_suelos', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolicitudSuelos = CType(o, dSolicitudSuelos)
        Dim sql As String = "UPDATE solicitud_suelos SET ficha= " & obj.FICHA & ", muestra='" & obj.MUESTRA & "', paquete=" & obj.PAQUETE & ", nitratos=" & obj.NITRATOS & ",mineralizacion=" & obj.MINERALIZACION & ",fosforobray=" & obj.FOSFOROBRAY & ",fosforocitrico=" & obj.FOSFOROCITRICO & ", phagua=" & obj.PHAGUA & ", phkci=" & obj.PHKCI & ", materiaorg=" & obj.MATERIAORG & ", potasioint=" & obj.POTASIOINT & ", sulfatos=" & obj.SULFATOS & ", nitrogenovegetal=" & obj.NITROGENOVEGETAL & ", calcio=" & obj.CALCIO & ", magnesio=" & obj.MAGNESIO & ", sodio=" & obj.SODIO & ", acideztitulable=" & obj.ACIDEZTITULABLE & ", cic=" & obj.CIC & ", sb=" & obj.SB & ", muestreo=" & obj.MUESTREO & ", zinc=" & obj.ZINC & ", isusaestandar=" & obj.ISUSAESTANDAR & ", isusazinc=" & obj.ISUSAZINC & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitud_suelos', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolicitudSuelos = CType(o, dSolicitudSuelos)
        Dim sql As String = "DELETE FROM solicitud_suelos WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitud_suelos', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar2(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dSolicitudSuelos = CType(o, dSolicitudSuelos)
        Dim sql As String = "DELETE FROM solicitud_suelos WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'solicitud_suelos', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dSolicitudSuelos
        Dim obj As dSolicitudSuelos = CType(o, dSolicitudSuelos)
        Dim ss As New dSolicitudSuelos
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, muestra, paquete, nitratos, mineralizacion, fosforobray, fosforocitrico, phagua, phkci, materiaorg, potasioint, sulfatos, nitrogenovegetal, calcio, magnesio, sodio, acideztitulable, cic, sb, muestreo, zinc, isusaestandar, isusazinc FROM solicitud_suelos WHERE ficha = " & obj.FICHA & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                ss.ID = CType(unaFila.Item(0), Long)
                ss.FICHA = CType(unaFila.Item(1), Long)
                ss.MUESTRA = CType(unaFila.Item(2), String)
                ss.PAQUETE = CType(unaFila.Item(3), Integer)
                ss.NITRATOS = CType(unaFila.Item(4), Integer)
                ss.MINERALIZACION = CType(unaFila.Item(5), Integer)
                ss.FOSFOROBRAY = CType(unaFila.Item(6), Integer)
                ss.FOSFOROCITRICO = CType(unaFila.Item(7), Integer)
                ss.PHAGUA = CType(unaFila.Item(8), Integer)
                ss.PHKCI = CType(unaFila.Item(9), Integer)
                ss.MATERIAORG = CType(unaFila.Item(10), Integer)
                ss.POTASIOINT = CType(unaFila.Item(11), Integer)
                ss.SULFATOS = CType(unaFila.Item(12), Integer)
                ss.NITROGENOVEGETAL = CType(unaFila.Item(13), Integer)
                ss.CALCIO = CType(unaFila.Item(14), Integer)
                ss.MAGNESIO = CType(unaFila.Item(15), Integer)
                ss.SODIO = CType(unaFila.Item(16), Integer)
                ss.ACIDEZTITULABLE = CType(unaFila.Item(17), Double)
                ss.CIC = CType(unaFila.Item(18), Double)
                ss.SB = CType(unaFila.Item(19), Double)
                ss.MUESTREO = CType(unaFila.Item(20), Integer)
                ss.ZINC = CType(unaFila.Item(21), Integer)
                ss.ISUSAESTANDAR = CType(unaFila.Item(22), Integer)
                ss.ISUSAZINC = CType(unaFila.Item(23), Integer)
                Return ss
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxfichaxmuestra(ByVal o As Object) As dSolicitudSuelos
        Dim obj As dSolicitudSuelos = CType(o, dSolicitudSuelos)
        Dim ss As New dSolicitudSuelos
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, muestra, paquete, nitratos, mineralizacion, fosforobray, fosforocitrico, phagua, phkci, materiaorg, potasioint, sulfatos, nitrogenovegetal, calcio, magnesio, sodio, acideztitulable, cic, sb, muestreo, zinc, isusaestandar, isusazinc FROM solicitud_suelos WHERE ficha = " & obj.FICHA & " AND muestra= '" & obj.MUESTRA & "'")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                ss.ID = CType(unaFila.Item(0), Long)
                ss.FICHA = CType(unaFila.Item(1), Long)
                ss.MUESTRA = CType(unaFila.Item(2), String)
                ss.PAQUETE = CType(unaFila.Item(3), Integer)
                ss.NITRATOS = CType(unaFila.Item(4), Integer)
                ss.MINERALIZACION = CType(unaFila.Item(5), Integer)
                ss.FOSFOROBRAY = CType(unaFila.Item(6), Integer)
                ss.FOSFOROCITRICO = CType(unaFila.Item(7), Integer)
                ss.PHAGUA = CType(unaFila.Item(8), Integer)
                ss.PHKCI = CType(unaFila.Item(9), Integer)
                ss.MATERIAORG = CType(unaFila.Item(10), Integer)
                ss.POTASIOINT = CType(unaFila.Item(11), Integer)
                ss.SULFATOS = CType(unaFila.Item(12), Integer)
                ss.NITROGENOVEGETAL = CType(unaFila.Item(13), Integer)
                ss.CALCIO = CType(unaFila.Item(14), Integer)
                ss.MAGNESIO = CType(unaFila.Item(15), Integer)
                ss.SODIO = CType(unaFila.Item(16), Integer)
                ss.ACIDEZTITULABLE = CType(unaFila.Item(17), Double)
                ss.CIC = CType(unaFila.Item(18), Double)
                ss.SB = CType(unaFila.Item(19), Double)
                ss.MUESTREO = CType(unaFila.Item(20), Integer)
                ss.ZINC = CType(unaFila.Item(21), Integer)
                ss.ISUSAESTANDAR = CType(unaFila.Item(22), Integer)
                ss.ISUSAZINC = CType(unaFila.Item(23), Integer)
                Return ss
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, muestra, paquete, nitratos, mineralizacion, fosforobray, fosforocitrico, phagua, phkci, materiaorg, potasioint, sulfatos, nitrogenovegetal, calcio, magnesio, sodio, acideztitulable, cic, sb, muestreo, zinc, isusaestandar, isusazinc FROM solicitud_suelos ORDER BY id DESC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim ss As New dSolicitudSuelos
                    ss.ID = CType(unaFila.Item(0), Long)
                    ss.FICHA = CType(unaFila.Item(1), Long)
                    ss.MUESTRA = CType(unaFila.Item(2), String)
                    ss.PAQUETE = CType(unaFila.Item(3), Integer)
                    ss.NITRATOS = CType(unaFila.Item(4), Integer)
                    ss.MINERALIZACION = CType(unaFila.Item(5), Integer)
                    ss.FOSFOROBRAY = CType(unaFila.Item(6), Integer)
                    ss.FOSFOROCITRICO = CType(unaFila.Item(7), Integer)
                    ss.PHAGUA = CType(unaFila.Item(8), Integer)
                    ss.PHKCI = CType(unaFila.Item(9), Integer)
                    ss.MATERIAORG = CType(unaFila.Item(10), Integer)
                    ss.POTASIOINT = CType(unaFila.Item(11), Integer)
                    ss.SULFATOS = CType(unaFila.Item(12), Integer)
                    ss.NITROGENOVEGETAL = CType(unaFila.Item(13), Integer)
                    ss.CALCIO = CType(unaFila.Item(14), Integer)
                    ss.MAGNESIO = CType(unaFila.Item(15), Integer)
                    ss.SODIO = CType(unaFila.Item(16), Integer)
                    ss.ACIDEZTITULABLE = CType(unaFila.Item(17), Double)
                    ss.CIC = CType(unaFila.Item(18), Double)
                    ss.SB = CType(unaFila.Item(19), Double)
                    ss.MUESTREO = CType(unaFila.Item(20), Integer)
                    ss.ZINC = CType(unaFila.Item(21), Integer)
                    ss.ISUSAESTANDAR = CType(unaFila.Item(22), Integer)
                    ss.ISUSAZINC = CType(unaFila.Item(23), Integer)
                    Lista.Add(ss)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfichas() As ArrayList
        Dim sql As String = "SELECT DISTINCT ficha FROM solicitud_suelos ORDER BY ficha ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim ss As New dSolicitudSuelos
                    ss.FICHA = CType(unaFila.Item(0), Long)
                    Lista.Add(ss)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, muestra, paquete, nitratos, mineralizacion, fosforobray, fosforocitrico, phagua, phkci, materiaorg, potasioint, sulfatos, nitrogenovegetal, calcio, magnesio, sodio, acideztitulable, cic, sb, muestreo, zinc, isusaestandar, isusazinc FROM solicitud_suelos where ficha = " & texto & " order by id desc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim ss As New dSolicitudSuelos
                    ss.ID = CType(unaFila.Item(0), Long)
                    ss.FICHA = CType(unaFila.Item(1), Long)
                    ss.MUESTRA = CType(unaFila.Item(2), String)
                    ss.PAQUETE = CType(unaFila.Item(3), Integer)
                    ss.NITRATOS = CType(unaFila.Item(4), Integer)
                    ss.MINERALIZACION = CType(unaFila.Item(5), Integer)
                    ss.FOSFOROBRAY = CType(unaFila.Item(6), Integer)
                    ss.FOSFOROCITRICO = CType(unaFila.Item(7), Integer)
                    ss.PHAGUA = CType(unaFila.Item(8), Integer)
                    ss.PHKCI = CType(unaFila.Item(9), Integer)
                    ss.MATERIAORG = CType(unaFila.Item(10), Integer)
                    ss.POTASIOINT = CType(unaFila.Item(11), Integer)
                    ss.SULFATOS = CType(unaFila.Item(12), Integer)
                    ss.NITROGENOVEGETAL = CType(unaFila.Item(13), Integer)
                    ss.CALCIO = CType(unaFila.Item(14), Integer)
                    ss.MAGNESIO = CType(unaFila.Item(15), Integer)
                    ss.SODIO = CType(unaFila.Item(16), Integer)
                    ss.ACIDEZTITULABLE = CType(unaFila.Item(17), Double)
                    ss.CIC = CType(unaFila.Item(18), Double)
                    ss.SB = CType(unaFila.Item(19), Double)
                    ss.MUESTREO = CType(unaFila.Item(20), Integer)
                    ss.ZINC = CType(unaFila.Item(21), Integer)
                    ss.ISUSAESTANDAR = CType(unaFila.Item(22), Integer)
                    ss.ISUSAZINC = CType(unaFila.Item(23), Integer)
                    Lista.Add(ss)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, ficha, muestra, paquete, nitratos, mineralizacion, fosforobray, fosforocitrico, phagua, phkci, materiaorg, potasioint, sulfatos, nitrogenovegetal, calcio, magnesio, sodio, acideztitulable, cic, sb, muestreo, zinc, isusaestandar, isusazinc FROM solicitud_suelos where ficha = " & texto & " order by muestra asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim ss As New dSolicitudSuelos
                    ss.ID = CType(unaFila.Item(0), Long)
                    ss.FICHA = CType(unaFila.Item(1), Long)
                    ss.MUESTRA = CType(unaFila.Item(2), String)
                    ss.PAQUETE = CType(unaFila.Item(3), Integer)
                    ss.NITRATOS = CType(unaFila.Item(4), Integer)
                    ss.MINERALIZACION = CType(unaFila.Item(5), Integer)
                    ss.FOSFOROBRAY = CType(unaFila.Item(6), Integer)
                    ss.FOSFOROCITRICO = CType(unaFila.Item(7), Integer)
                    ss.PHAGUA = CType(unaFila.Item(8), Integer)
                    ss.PHKCI = CType(unaFila.Item(9), Integer)
                    ss.MATERIAORG = CType(unaFila.Item(10), Integer)
                    ss.POTASIOINT = CType(unaFila.Item(11), Integer)
                    ss.SULFATOS = CType(unaFila.Item(12), Integer)
                    ss.NITROGENOVEGETAL = CType(unaFila.Item(13), Integer)
                    ss.CALCIO = CType(unaFila.Item(14), Integer)
                    ss.MAGNESIO = CType(unaFila.Item(15), Integer)
                    ss.SODIO = CType(unaFila.Item(16), Integer)
                    ss.ACIDEZTITULABLE = CType(unaFila.Item(17), Double)
                    ss.CIC = CType(unaFila.Item(18), Double)
                    ss.SB = CType(unaFila.Item(19), Double)
                    ss.MUESTREO = CType(unaFila.Item(20), Integer)
                    ss.ZINC = CType(unaFila.Item(21), Integer)
                    ss.ISUSAESTANDAR = CType(unaFila.Item(22), Integer)
                    ss.ISUSAZINC = CType(unaFila.Item(23), Integer)
                    Lista.Add(ss)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
