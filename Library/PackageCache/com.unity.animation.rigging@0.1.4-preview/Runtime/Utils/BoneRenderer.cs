using System.Collections.Generic;

namespace UnityEngine.Animations.Rigging
{
    [ExecuteInEditMode]
    [AddComponentMenu("Animation Rigging/Setup/Bone Renderer")]
    public class BoneRenderer : MonoBehaviour
    {
    #if UNITY_EDITOR
        public enum BoneShape
        {
            Line,
            Pyramid,
            Box
        };

        public struct TransformPair
        {
            public Transform first;
            public Transform second;
        };

        public BoneShape boneShape = BoneShape.Pyramid;

        public bool drawBones = true;
        public bool drawTripods = false;

        [Range(0.01f, 5.0f)]
        public float boneSize = 1.0f;

        [Range(0.01f, 5.0f)]
        public float tripodSize = 1.0f;

        public Color boneColor = new Color(0f, 1.0f, 0f, 0.5f);

        [SerializeField]
        private Transform[] m_Transforms;

        private TransformPair[] m_Bones;

        private Transform[] m_Tips;

        public Transform[] transforms
        {
            get { return m_Transforms; }
            set
            {
                m_Transforms = value;
                ExtractBones();
            }
        }

        public TransformPair[] bones { get => m_Bones; }

        public Transform[] tips { get => m_Tips; }

        void OnEnable()
        {
            ExtractBones();
            BoneRendererUtil.OnBoneRendererEnabled(this);
        }

        void OnDisable()
        {
            BoneRendererUtil.OnBoneRendererDisabled(this);
        }

        void Reset()
        {
            ClearBones();
        }

        void ClearBones()
        {
            m_Bones = null;
            m_Tips = null;
        }

        public void ExtractBones()
        {
            if (m_Transforms == null || m_Transforms.Length == 0)
            {
                ClearBones();
                return;
            }

            var transformsHashSet = new HashSet<Transform>(m_Transforms);

            var bonesList = new List<TransformPair>(m_Transforms.Length);
            var tipsList = new List<Transform>(m_Transforms.Length);

            for (int i = 0; i < m_Transforms.Length; ++i)
            {
                bool hasValidChildren = false;

                var transform  = m_Transforms[i];
                if (transform == null)
                    continue;

                if (transform.childCount > 0)
                {

                    for (var k = 0; k < transform.childCount; ++k)
                    {
                        var childTransform = transform.GetChild(k);

                        if (transformsHashSet.Contains(childTransform))
                        {
                            bonesList.Add(new TransformPair() { first = transform, second = childTransform });
                            hasValidChildren = true;
                        }
                    }
                }

                if (!hasValidChildren)
                {
                    tipsList.Add(transform);
                }
            }

            m_Bones = bonesList.ToArray();
            m_Tips = tipsList.ToArray();
        }
    #endif // UNITY_EDITOR
    }
}
